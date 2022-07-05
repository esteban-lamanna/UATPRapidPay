using System;

namespace UATPRapidPay.Card.Infrastructure.Models
{
    internal class ReadPurchaseModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public ReadCardModel Card { get; set; }
    }
}