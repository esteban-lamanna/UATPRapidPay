using System;

namespace UATPRapidPay.Card.Api.Models.Card
{
    public class CreateCardResponse
    {
        public string CardNumber { get; set; }
        public Guid CardId { get; set; }
    }
}