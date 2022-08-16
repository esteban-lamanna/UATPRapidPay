using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.Repositories;
using UATPRapidPay.Card.Infrastructure.EF;

namespace UATPRapidPay.Card.Infrastructure.Repositories
{
    internal class PurchaseRepository : IPurchaseRepository
    {
        private readonly WriteDbContext _writeDbContext;
        public PurchaseRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public async Task CreateAsync(Purchase purchase)
        {
            _writeDbContext.Add(purchase);

            await _writeDbContext.SaveChangesAsync();
        }
    }
}