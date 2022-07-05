using System;
using System.Collections.Generic;
using UATPRapidPay.Card.Domain.ValueObjects;
using UATPRapidPay.Shared.Entities;

namespace UATPRapidPay.Card.Domain.Entities
{
    public class Person : AggregateRoot<Guid>
    {
        public virtual IEnumerable<Card> Cards { get; }

        private List<Card> _cards = new();

        public Name Name { get; protected set; }

        public Email Email { get; protected set; }

        public Person(Email email, Name name)
        {
            Name = name;
            Email = email;
        }
    }
}