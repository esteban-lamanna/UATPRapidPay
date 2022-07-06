using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Application.DTO
{
    public class GetCardDTO
    {
        public CardNumber CardNumber { get; set; }
        public decimal Limit { get; set; }
        public Name PersonName { get; set; }
        public ExpirationDate ExpirationDate { get; set; }
    }
}