using Microsoft.Extensions.Logging;
using Moq;
using UATPRapidPay.Card.Api.Controllers.Card;
using UATPRapidPay.Card.Api.Models.Card;
using UATPRapidPay.Card.Application.DTO;
using UATPRapidPay.Card.Application.Queries;
using UATPRapidPay.Shared.Commands;
using UATPRapidPay.Shared.Queries;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using UATPRapidPay.Card.Domain.ValueObjects;
using System.Net;
using UATPRapidPay.Card.Application.Commands;

namespace UATPRapidPay.Card.Presentation.API.Tests
{
    public class CreateCardControllerShould
    {
        [Fact]
        public async Task ReturnActionResult()
        {
            //arrange
            var commandDispatcher = new Mock<ICommandDispatcher>();
            var queryDispatcher = new Mock<IQueryDispatcher>();
            var expectedCardNumber = new CardNumber("1234567891234567");

            var queryDTO = queryDispatcher
                  .Setup(a => a.QueryAsync(It.IsAny<GetCardQuery>()))
                  .ReturnsAsync(new GetCardDTO()
                  {
                      CardNumber = expectedCardNumber
                  });

            var controller = new CreateCardController(commandDispatcher.Object,
                                                      queryDispatcher.Object);

            //act
            var result = await controller.Create(new CreateCardRouteRequest(), new CreateCardRequest());

            //assert
            commandDispatcher.Verify(a => a.SendAsync(It.IsAny<CreateCardCommand>()), Times.Once);
            queryDispatcher.Verify(a => a.QueryAsync(It.IsAny<GetCardQuery>()), Times.Once);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.StatusCode.ShouldBe((int)HttpStatusCode.OK);
            var value = (CardNumber)okResult.Value;
            value.ShouldBe(expectedCardNumber);
        }
    }
}