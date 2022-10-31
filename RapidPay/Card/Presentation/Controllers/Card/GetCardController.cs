using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UATPRapidPay.Card.Api.Models.Card;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Api.Controllers.Card
{
    [Authorize]
    [ApiController]
    [Route("Card")]
    public class GetCardController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public GetCardController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [Route("{CardNumber}")]
        [HttpGet("{CardNumber}")]
        public async Task<IActionResult> Get([FromRoute] GetCardRequest getCardRequest)
        {
            var cardDto = await _queryDispatcher.QueryAsync(getCardRequest.ToQuery());

            if (cardDto == null)
                return NotFound();

            return Ok(cardDto);
        }
    }
}