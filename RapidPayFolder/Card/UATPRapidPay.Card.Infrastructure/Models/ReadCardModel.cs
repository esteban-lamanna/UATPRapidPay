using System;
using System.Collections.Generic;

namespace UATPRapidPay.Card.Infrastructure.Models
{
    internal class ReadCardModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Limit { get; set; }
        public ReadPersonModel Person { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public IEnumerable<ReadPurchaseModel> ProductsBougth { get; set; }
    }
}