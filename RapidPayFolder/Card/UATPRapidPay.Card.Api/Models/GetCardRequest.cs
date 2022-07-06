using System.ComponentModel.DataAnnotations;

namespace UATPRapidPay.Card.Api.Models
{
    public class GetCardRequest
    {
        [MaxLength(16)]
        [MinLength(16)]
        [Required]
        public string CardNumber { get; set; }
    }
}