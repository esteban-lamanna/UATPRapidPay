using System;
using UATPRapidPay.Card.Domain.ValueObjects;
using UATPRapidPay.Shared.Entities;

namespace UATPRapidPay.Card.Domain.Entities
{
    public class Purchase : AggregateRoot<Guid>
    {
        public decimal Price { get; protected set; }
        public ProductName ProductName { get; protected set; }
        public PurchaseDate PurchaseDate { get; protected set; }
        public Card Card { get; protected set; }
    }
}