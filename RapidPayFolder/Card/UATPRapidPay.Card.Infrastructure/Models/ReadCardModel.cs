using System;
using System.Collections.Generic;
using UATPRapidPay.Card.Application.DTO;

namespace UATPRapidPay.Card.Infrastructure.Models
{
    public class ReadCardModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Limit { get; set; }
     //   public virtual ReadPersonModel Person { get; set; }
        public DateOnly ExpirationDate { get; set; }
     //   public virtual ICollection<ReadPurchaseModel> ProductsBougth { get; set; }       
    }
}