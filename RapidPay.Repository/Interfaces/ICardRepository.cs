using Domain.RapidPay.Entities;
using System.Collections.Generic;

namespace Drivers.RapidPay.Repository
{
    public interface ICardRepository
    {
        void Create(Card card);
        IEnumerable<Card> GetAll();
    }
}