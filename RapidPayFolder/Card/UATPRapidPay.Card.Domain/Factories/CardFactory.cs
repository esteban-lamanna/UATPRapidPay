using Microsoft.Extensions.Internal;
using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.DomainEvents;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Domain.Factories
{
    public class CardFactory : ICardFactory
    {
        private readonly ICardNumberFactory _cardNumberFactory;
        private readonly ISystemClock _systemClock;

        public CardFactory(ICardNumberFactory cardNumberFactory, ISystemClock systemClock)
        {
            _cardNumberFactory = cardNumberFactory;
            _systemClock = systemClock;
        }

        public async Task<Entities.Card> Create(Guid id,
                                                Person person,
                                                Limit limit)
        {
            var cardNumber = await _cardNumberFactory.GenerateAsync(person);

            var expiryDate = _systemClock.UtcNow.AddMonths(5).DateTime;

            var dateExpirationDate = DateOnly.FromDateTime(expiryDate);

            var card = new Entities.Card(id, cardNumber, person, dateExpirationDate, limit);

            card.AddEvent(new CardCreated(card.Id, card.Limit, card.Person.Id));

            return card;
        }
    }
}