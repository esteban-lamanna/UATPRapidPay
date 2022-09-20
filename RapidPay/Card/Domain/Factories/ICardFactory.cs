using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Domain.Factories
{
    public interface ICardFactory
    {
        public Task<Entities.Card> Create(Guid id, Person person, Limit limit);
    }
}