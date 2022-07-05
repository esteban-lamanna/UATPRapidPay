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

        public CardNumber CardNumber { get; private set; }
        public Person Person { get; private set; }
        public ExpirationDate ExpirationDate { get; private set; }
        public decimal Limit { get; private set; }
        public IEnumerable<Purchase> ProductsBougth { get; private set; }

        private ICollection<Purchase> _productsBougth;    
    }
}