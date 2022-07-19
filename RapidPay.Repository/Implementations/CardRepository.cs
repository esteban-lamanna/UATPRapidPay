using RapidPay.EnterpriseBusinessRules.Entities;
using RapidPay.EnterpriseBusinessRules.Entities.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RapidPay.InterfaceAdapters.Gateways.Repository.EF.Implementations
{
    public class CardRepository : ICardRepository
    {
        private readonly RapidPayContext _rapidPayContext;

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