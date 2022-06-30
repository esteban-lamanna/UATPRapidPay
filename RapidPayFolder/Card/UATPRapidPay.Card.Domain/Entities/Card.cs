using System.Collections.Generic;
using UATPRapidPay.Card.Domain.ValueObjects;
using UATPRapidPay.Shared.Entities;

namespace UATPRapidPay.Card.Domain.Entities
{
    public class Card : AggregateRoot<CardNumber>
    {
        public Card(CardNumber cardNumber,
                    Person person,
                    ExpirationDate expirationDate,
                    decimal limit)
        {
            CardNumber = cardNumber;
            Person = person;
            ExpirationDate = expirationDate;
            Limit = limit;
        }

        public CardNumber CardNumber { get; protected set; }
        public Person Person { get; protected set; }
        public ExpirationDate ExpirationDate { get; protected set; }
        public decimal Limit { get; protected set; }
        public IEnumerable<Purchase> ProductsBougth { get; protected set; }
    }
}