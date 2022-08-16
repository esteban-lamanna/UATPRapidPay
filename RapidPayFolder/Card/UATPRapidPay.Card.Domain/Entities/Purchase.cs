using System;
using UATPRapidPay.Card.Domain.DomainEvents;
using UATPRapidPay.Card.Domain.ValueObjects;
using UATPRapidPay.Shared.Entities;

namespace UATPRapidPay.Card.Domain.Entities
{
    public class Purchase : AggregateRoot<Guid>
    {
        //EF
        private Purchase()
        {

        }

        public Purchase(Guid id,Card card, Price price, ProductName productName, PurchaseDate purchaseDate)
        {
            Id = id;
            Price = price;
            ProductName = productName;
            PurchaseDate = purchaseDate;
            Card = card;
        }

        public Price Price { get; protected set; }
        public ProductName ProductName { get; protected set; }
        public PurchaseDate PurchaseDate { get; protected set; }
        public Card Card { get; protected set; }


        public static Purchase Create(Guid id, Card card, Price price, ProductName productName)
        {
            var purchase = new Purchase(id, card, price, productName, (PurchaseDate)DateTime.UtcNow);

            purchase.AddEvent(new PurchaseCreated(card.Id, price, productName));

            return purchase;
        }
    }
}