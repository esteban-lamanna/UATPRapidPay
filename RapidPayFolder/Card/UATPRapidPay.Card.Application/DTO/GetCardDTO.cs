using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Application.DTO
{
    public class GetCardDTO
    {
        public CardNumber CardNumber { get; set; }
        public decimal Limit { get; set; }
        public Name PersonName { get; set; }
        public Email PersonEmail { get; set; }
        public ExpirationDate ExpirationDate { get; set; }


        public static explicit operator GetCardDTO(Domain.Entities.Card v)
        {
            if (v == null)
                return null;

            return new GetCardDTO()
            {
                CardNumber = v.CardNumber,
                Limit = v.Limit,
                ExpirationDate = v.ExpirationDate,
                PersonEmail = v.Person.Email,
                PersonName = v.Person.Name
            };
        }
    }
}