﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UATPRapidPay.Card.Api.Models;
using UATPRapidPay.Card.Application.Queries;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Api.Controllers.Card
{
    [ApiController]
    [Route("Card")]
    public class GetCardController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public GetCardController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [Route("Card/{CardNumber}")]
        [HttpGet("{CardNumber}")]
        public async Task<IActionResult> Get([FromRoute] GetCardRequest getCardRequest)
        {
            Application.DTO.GetCardDTO cardDto = await _queryDispatcher.QueryAsync(new GetCardQuery()
            {
                CardNumber = getCardRequest.CardNumber
            });

            if (cardDto == null)
                return NotFound();

            return Ok(cardDto);
        }
    }
}