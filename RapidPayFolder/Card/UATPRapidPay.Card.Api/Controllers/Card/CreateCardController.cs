using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using UATPRapidPay.Card.Api.Attributes;
using UATPRapidPay.Card.Api.Models.Card;
using UATPRapidPay.Shared.Commands;

namespace UATPRapidPay.Card.Api.Controllers.Card
{
    [ApiController]
    public class CreateCardController : ControllerBase
    {
        private readonly ILogger<CreateCardController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public CreateCardController(ILogger<CreateCardController> logger,
                                    ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }

        [Route("Person/{PersonId}/Card/{CardId}")]
        [HttpPost]
        public async Task<IActionResult> Create([FromRoute] CreateCardRouteRequest route, [FromBody] CreateCardRequest createCardRequest)
        {
            var request = new CreateCardRequest()
            {
                Limit = createCardRequest.Limit,
                CardId = route.CardId,
                PersonId = route.PersonId
            };

            await _commandDispatcher.SendAsync(request.ToCommand());

            return CreatedAtAction(actionName: nameof(GetCardController.Get),
                                   controllerName: nameof(GetCardController),
                                   new { },
                                   new { asd = 23 });
        }
    }   
}