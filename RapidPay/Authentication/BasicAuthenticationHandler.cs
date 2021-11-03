using Domain.RapidPay.DTO;
using Domain.RapidPay.UseCasesPorts;
using InterfaceAdapters.RapidPay.Presenters;
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

namespace Drivers.RapidPay.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        readonly ILoginUserInputPort _loginUserInputPort;
        readonly ILoginUserOutputPort _loginUserOutputPort;

        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOptions> options,
                                          ILoggerFactory logger,
                                          UrlEncoder encoder,
                                          ISystemClock clock,
                                          ILoginUserInputPort loginUserInputPort,
                                          ILoginUserOutputPort loginUserOutputPort)

        : base(options, logger, encoder, clock)
        {
            _loginUserInputPort = loginUserInputPort;
            _loginUserOutputPort = loginUserOutputPort;
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

            _loginUserInputPort.HandleAsync(new LoginUserDTO()
            {
                Password = password,
                Username = authUsername
            })
                .GetAwaiter()
                .GetResult();

            var userDto = ((IPresenter<UserDTO>)_loginUserOutputPort).Content;

            if (userDto == null)
                return Task.FromResult(AuthenticateResult.Fail("Invalid credentials"));

            var list = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, authUsername),
                new Claim("Id", userDto.Id.ToString()),
            };

            var identity = new ClaimsIdentity(list, "Basic");

            var claimsPrincipal = new ClaimsPrincipal(identity);

            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
        }
    }
}