using RapidPay.EnterpriseBusinessRules.Entities;
using System.Collections.Generic;

namespace RapidPay.EnterpriseBusinessRules.Entities.Repositories
{
    public interface ICardRepository
    {
        void Create(Card card);
        IEnumerable<Card> GetAll();
    }
}