using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Domain.Repositories
{
    public interface ICardRepository
    {
        Task<Entities.Card> GetByNumberAsync(CardNumber cardNumber);
        Task CreateAsync(Entities.Card card);
    }
}