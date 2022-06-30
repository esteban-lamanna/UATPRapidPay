using System.ComponentModel.DataAnnotations;

namespace UATPRapidPay.Card.Api.Models
{
    public class GetCardRequest
    {
        [Required]
        public string CardNumber { get; set; }
    }
}