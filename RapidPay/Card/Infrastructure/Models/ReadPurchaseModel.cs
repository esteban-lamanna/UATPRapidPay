using System;

namespace UATPRapidPay.Card.Infrastructure.Models
{
    public class ReadPurchaseModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int IdCard { get; set; }
     //   public virtual ReadCardModel Card { get; set; }
    }
}