using System;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Domain.Factories
{
    public class CardFactory : ICardFactory
    {
        public Entities.Card Create(Guid id, CardNumber cardNumber, Person person, ExpirationDate expirationDate, decimal limit)
        {
            return new Entities.Card(id, cardNumber, person, expirationDate, limit);
        }
    }
}