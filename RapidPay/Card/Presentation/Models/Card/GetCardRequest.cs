using System.ComponentModel.DataAnnotations;
using UATPRapidPay.Card.Application.Queries;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Api.Models.Card
{
    public class GetCardRequest
    {
        [MaxLength(16)]
        [MinLength(16)]
        [Required]
        public string CardNumber { get; set; }
    }

    internal static class GetCardRequestExtensions
    {
        internal static GetCardQuery ToQuery(this GetCardRequest request)
        {
            return new GetCardQuery()
            {
                CardNumber = new CardNumber(request.CardNumber)
            };
        }
    }
}