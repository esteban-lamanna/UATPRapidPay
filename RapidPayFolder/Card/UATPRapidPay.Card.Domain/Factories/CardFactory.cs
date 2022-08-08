using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Domain.Factories
{
    public class CardFactory : ICardFactory
    {
        private readonly ICardNumberFactory _cardNumberFactory;

        public CardFactory(ICardNumberFactory cardNumberFactory)
        {
            _cardNumberFactory = cardNumberFactory;
        }

        public async Task<Entities.Card> Create(Guid id,
                                                Person person,
                                                Limit limit)
        {
            var cardNumber = await _cardNumberFactory.Generate(person);

            var expiryDate = DateTime.UtcNow.AddMonths(5);

            var dateExpirationDate = DateOnly.FromDateTime(expiryDate);

            return new Entities.Card(id, cardNumber, person, dateExpirationDate, limit);
        }
    }
}