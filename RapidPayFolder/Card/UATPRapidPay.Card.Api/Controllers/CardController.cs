using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using UATPRapidPay.Card.Api.Models;

namespace UATPRapidPay.Card.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;

        public CardController(ILogger<CardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{CardNumber}")]
        public async Task<IActionResult> Get([FromRoute] GetCardRequest getCardRequest)
        {
            return Ok("sd");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCardRequest createCardRequest)
        {
            return Ok("sd");
        }
    }
}