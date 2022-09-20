using Moq;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.Factories;
using UATPRapidPay.Card.Domain.ValueObjects;
using Shouldly;
using UATPRapidPay.Card.Domain.DomainEvents;
using Microsoft.Extensions.Internal;

namespace UATPRapidPay.Card.Domain.Tests
{
    public class CardFactoryShould
    {
        [Fact]
        public async Task ReturnCard()
        {
            //arrange
            var person = new Person(Guid.NewGuid(), new Email("asd@asd.com"), new Name("asd"));
            var cardNumberGenerated = new CardNumber("1234567891234567");
            var cardId = Guid.NewGuid();
            var limit = new Limit(23);
            var now = DateTime.UtcNow;

            var systemClock = new Mock<ISystemClock>();
            systemClock.Setup(a => a.UtcNow).Returns(now);

            var cardNumberFactory = new Mock<ICardNumberFactory>();
            cardNumberFactory.Setup(a => a.GenerateAsync(It.IsAny<Person>())).ReturnsAsync(cardNumberGenerated);
            var cardFactory = new CardFactory(cardNumberFactory.Object, systemClock.Object);

            //act
            var card = await cardFactory.Create(cardId, person, limit);

            //assert
            card.ShouldNotBeNull();
            card.Id.ShouldBe(cardId);
            card.Person.ShouldBe(person);
            card.Limit.ShouldBe(limit);

            var expiryDate = DateOnly.FromDateTime(now.AddMonths(5));
            card.ExpirationDate.ShouldBe(new ExpirationDate(expiryDate));

            var @event = card.Events.Single();
            @event.ShouldBeOfType<CardCreated>();
        }
    }
}