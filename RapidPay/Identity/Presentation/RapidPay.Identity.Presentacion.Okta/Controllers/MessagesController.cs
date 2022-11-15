using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RapidPay.Identity.Presentacion.Okta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        public IActionResult Get()
        {
            var principal = HttpContext.User.Identity as ClaimsIdentity;

            var login = principal?.Claims
                .SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;

            return Ok(
                new dynamic[]
                {
                    new { Date = DateTime.Now, Text = "I am a Robot." },
                    new { Date = DateTime.Now, Text = "Hello, world!" },
                });
        }
    }
}