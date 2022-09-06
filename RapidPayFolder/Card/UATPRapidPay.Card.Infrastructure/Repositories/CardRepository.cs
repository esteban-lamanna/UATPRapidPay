using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<Domain.Entities.Card> GetByNumberAsync(CardNumber cardNumber)
        {
            return await _writeDbContext.Set<Domain.Entities.Card>()
                    .SingleOrDefaultAsync(c => c.CardNumber == cardNumber);
        }

        public async Task<CardNumber> GetLastCardNumberAsync()
        {
            return await _writeDbContext.Set<Domain.Entities.Card>()
                                              .OrderByDescending(c => c.CardNumber)
                                              .Select(a => a.CardNumber)
                                              .FirstOrDefaultAsync();
        }
    }
}