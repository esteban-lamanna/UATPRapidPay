using System;
using System.Collections.Generic;
using UATPRapidPay.Card.Domain.ValueObjects;
using UATPRapidPay.Shared.Entities;

namespace UATPRapidPay.Card.Domain.Entities
{
    public class Card : AggregateRoot<Guid>
    {
        public Card(Guid id, 
                    CardNumber cardNumber,
                    Person person,
                    ExpirationDate expirationDate,
                    Limit limit)
        {
            Id = id;
            CardNumber = cardNumber;
            Person = person;
            ExpirationDate = expirationDate;
            Limit = limit;
        }

        //EF
        private Card()
        {
        }

        public CardNumber CardNumber { get; private set; }
        public Person Person { get; private set; }
        public ExpirationDate ExpirationDate { get; private set; }
        public Limit Limit { get; private set; }
        public IEnumerable<Purchase> ProductsBougth { get; private set; }
        private ICollection<Purchase> _productsBougth = new List<Purchase>();    
    }
}