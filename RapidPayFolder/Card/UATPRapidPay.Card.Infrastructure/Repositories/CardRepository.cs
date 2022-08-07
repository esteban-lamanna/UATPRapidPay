using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Repositories;
using UATPRapidPay.Card.Domain.ValueObjects;
using UATPRapidPay.Card.Infrastructure.EF;

namespace UATPRapidPay.Card.Infrastructure.Repositories
{
    internal class CardRepository : ICardRepository
    {
        private readonly WriteDbContext _writeDbContext;

        public CardRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public async Task CreateAsync(Domain.Entities.Card card)
        {
            _writeDbContext.Add(card);

            await _writeDbContext.SaveChangesAsync();
        }

        public Task<Domain.Entities.Card> GetByNumberAsync(CardNumber cardNumber)
        {
            throw new NotImplementedException();
        }
    }
}