using System;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Domain.Entities
{
    public class Purchase
    {
        public decimal Price { get; protected set; }
        public ProductName ProductName { get; protected set; }
        public PurchaseDate PurchaseDate { get; protected set; }
        public Card Card { get; protected set; }
    }
}