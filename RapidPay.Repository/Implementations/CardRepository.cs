using Domain.RapidPay.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Drivers.RapidPay.Repository
{
    public class CardRepository : ICardRepository
    {
        readonly RapidPayContext _rapidPayContext;

        public CardRepository(RapidPayContext rapidPayContext)
        {
            _rapidPayContext = rapidPayContext;
        }

        public void Create(Card card)
        {
            _rapidPayContext.Attach(card);
        }

        public IEnumerable<Card> GetAll()
        {
            return _rapidPayContext.Set<Card>().ToList();
        }
    }
}