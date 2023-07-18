using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Threading.Tasks;
using UATPRapidPay.Card.Api.Models.Card;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Api.Controllers.Card
{
    //[Authorize]
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
     //   [Authorize(Roles = "User")]
        public async Task<IActionResult> Get([FromRoute] GetCardRequest getCardRequest)
        {
            var u = User;

            var cardDto = await _queryDispatcher.QueryAsync(getCardRequest.ToQuery());

            if (cardDto == null)
                return NotFound();

            return Ok(cardDto);
        }
    }
}