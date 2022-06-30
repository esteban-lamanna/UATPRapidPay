using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Domain.Factories
{
    public class CardFactory : ICardFactory
    {
        public Entities.Card Create(CardNumber cardNumber, Person person, ExpirationDate expirationDate, decimal limit)
        {
            return new Entities.Card(cardNumber, person, expirationDate, limit);
        }
    }
}