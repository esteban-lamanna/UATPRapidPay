using System;
using UATPRapidPay.Card.Domain.ValueObjects;
using UATPRapidPay.Shared;

namespace UATPRapidPay.Card.Domain.DomainEvents
{
    public class PurchaseCreated : IDomainEvent
    {
        public PurchaseCreated(Guid cardId, Price price, ProductName productName)
        {
            CardId = cardId;
            Price = price;
            ProductName = productName;
        }

        public Guid CardId { get; private set; }
        public Price Price { get; private set; }
        public ProductName ProductName { get; private set; }
    }
}