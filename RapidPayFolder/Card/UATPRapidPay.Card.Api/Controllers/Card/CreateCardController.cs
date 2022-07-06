using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using UATPRapidPay.Card.Api.Models;
using UATPRapidPay.Card.Application.Commands;
using UATPRapidPay.Shared.Commands;

namespace UATPRapidPay.Card.Api.Controllers.Card
{
    [ApiController]
    [Route("Card")]
    public class CreateCardController : ControllerBase
    {
        private readonly ILogger<CreateCardController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public CreateCardController(ILogger<CreateCardController> logger, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCardRequest createCardRequest)
        {
            await _commandDispatcher.SendAsync(new CreateCardCommand()
            {
                Id = createCardRequest.Id,
                PersonName = createCardRequest.PersonName,
            });

            return CreatedAtAction(actionName: nameof(GetCardController.Get),
                                   controllerName: nameof(GetCardController),
                                   new { },
                                   new { asd = 23 });
        }
    }
}