﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Api.Models.Card;
using UATPRapidPay.Card.Application.Queries;
using UATPRapidPay.Shared.Commands;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Api.Controllers.Card
{
    [ApiController]
    public class CreateCardController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public CreateCardController(ICommandDispatcher commandDispatcher,
                                    IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [Route("Person/{PersonId}/Card")]
        [HttpPost]
        public async Task<IActionResult> Create([FromRoute] CreateCardRouteRequest route, [FromBody] CreateCardRequest createCardRequest)
        {
            var request = new CreateCardRequest()
            {
                Limit = createCardRequest.Limit,
                PersonId = route.PersonId
            };
            var command = request.ToCommand();
            var newId = Guid.NewGuid();
            command.CardId = newId;

            await _commandDispatcher.SendAsync(command);

            var queryCard = await _queryDispatcher.QueryAsync(new GetCardQuery() { Id = newId });

            return Ok(new CreateCardResponse()
            {
                CardNumber = queryCard.CardNumber,
                CardId = newId
            });
        }
    }
}