using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using UATPRapidPay.Card.Api.Models.Person;
using UATPRapidPay.Card.Application.Queries;
using UATPRapidPay.Shared.Commands;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Person.Api.Controllers.Person
{
    [ApiController]
    [Route("Person")]
    public class CreatePersonController : ControllerBase
    {
        private readonly ILogger<CreatePersonController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public CreatePersonController(ILogger<CreatePersonController> logger,
                                      ICommandDispatcher commandDispatcher,
                                      IQueryDispatcher queryDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonRequest createPersonRequest)
        {
            await _commandDispatcher.SendAsync(createPersonRequest.ToCommand());

            var dto = await _queryDispatcher.QueryAsync(new GetPersonQuery()
            {
                Id = createPersonRequest.Id
            });

            return CreatedAtRoute(routeName: "GetPersonById",
                                  routeValues: new { dto.Id },
                                  value: dto);
        }
    }
}