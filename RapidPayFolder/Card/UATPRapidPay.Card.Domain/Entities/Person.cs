using System;
using System.Collections.Generic;
using UATPRapidPay.Shared.Entities;

namespace UATPRapidPay.Card.Domain.Entities
{
    public class Person : AggregateRoot<Guid>
    {
        public IEnumerable<Card> Cards { get; }
        private List<Card> _cards = new List<Card>();

        public string Name { get; protected set; }
        
        public Guid Id { get; protected set; }

        public string Email { get; protected set; }



        public Person()
        {

        }


    }
}