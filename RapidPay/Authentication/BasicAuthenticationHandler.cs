using Domain.RapidPay.Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Presentation.RapidPay.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        readonly IUserLoginLogic _userLoginLogic;

        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOptions> options,
                                          ILoggerFactory logger,
                                          UrlEncoder encoder,
                                          ISystemClock clock,
                                          IUserLoginLogic userLoginLogic)

        : base(options, logger, encoder, clock)
        {
            _userLoginLogic = userLoginLogic;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Response.Headers.Add("WWW-Authenticate", "Basic");

            if (!Request.Headers.ContainsKey("Authorization"))
                return Task.FromResult(AuthenticateResult.Fail("Authorization header missing."));

            // Get authorization key
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var authHeaderRegex = new Regex(@"Basic (.*)");

            if (!authHeaderRegex.IsMatch(authorizationHeader))
                return Task.FromResult(AuthenticateResult.Fail("Authorization code not formatted properly."));

            var authBase64 = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderRegex.Replace(authorizationHeader, "$1")));
            var authSplit = authBase64.Split(Convert.ToChar(":"), 2);
            var authUsername = authSplit[0];
            var password = authSplit[1];

            var user = _userLoginLogic.Authenticate(authUsername, password).GetAwaiter().GetResult();

            if (user == null)
                return Task.FromResult(AuthenticateResult.Fail("Invalid credentials"));

            var list = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, authUsername),
                new Claim("Id", user.Id.ToString()),
            };

            var identity = new ClaimsIdentity(list, "Basic");

            var claimsPrincipal = new ClaimsPrincipal(identity);

            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
        }
    }
}