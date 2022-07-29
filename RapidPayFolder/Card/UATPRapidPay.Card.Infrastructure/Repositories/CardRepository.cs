using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Repositories;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Infrastructure.Repositories
{
    internal class CardRepository : ICardRepository
    {
        public Task CreateAsync(Domain.Entities.Card card)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Card> GetByNumberAsync(CardNumber cardNumber)
        {
            throw new NotImplementedException();
        }
    }
}