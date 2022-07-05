using System;
using System.Collections.Generic;

namespace UATPRapidPay.Card.Infrastructure.Models
{
    public class ReadCardModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Limit { get; set; }
      //  public virtual ReadPersonModel Person { get; set; }
        public DateOnly ExpirationDate { get; set; }
      //  public virtual IEnumerable<ReadPurchaseModel> ProductsBougth { get; set; }
    }
}