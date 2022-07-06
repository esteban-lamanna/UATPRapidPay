using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using UATPRapidPay.Card.Api.Models;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly IQueryDispatcher _queryDispatcher;

        public CardController(ILogger<CardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{CardNumber}")]
        public async Task<IActionResult> Get([FromRoute] GetCardRequest getCardRequest)
        {
            await _queryDispatcher
            
            return Ok("sd");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCardRequest createCardRequest)
        {
            return Ok("sd");
        }
    }
}