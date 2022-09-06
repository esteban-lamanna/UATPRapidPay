using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Entities;

namespace UATPRapidPay.Card.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        Task CreateAsync(Purchase purchase);
    }
}