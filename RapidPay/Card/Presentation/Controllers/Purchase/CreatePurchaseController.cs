using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using UATPRapidPay.Card.Api.Models.Person;
using UATPRapidPay.Card.Api.Models.Purchase;
using UATPRapidPay.Shared.Commands;

namespace UATPRapidPay.Person.Api.Controllers.Person
{
    [ApiController]
    public class CreatePurchaseController : ControllerBase
    {
        private readonly ILogger<CreatePurchaseController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public CreatePurchaseController(ILogger<CreatePurchaseController> logger,
                                      ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }

        [Route("Card/{CardNumber}/Purchase")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromRoute] CreatePurchaseFromRouteRequest createPurchaseFromRoute,
                                                [FromBody] CreatePurchaseFromBodyRequest createPurchaseFromBodyRequest)
        {
            var request = new CreatePurchaseRequest()
            {
                CardNumber = createPurchaseFromRoute.CardNumber,
                Price = createPurchaseFromBodyRequest.Price,
                ProductName = createPurchaseFromBodyRequest.ProductName,
                PurchaseId = createPurchaseFromBodyRequest.PurchaseId
            };

            await _commandDispatcher.SendAsync(request.ToCommand());

            return Ok();
        }
    }
}