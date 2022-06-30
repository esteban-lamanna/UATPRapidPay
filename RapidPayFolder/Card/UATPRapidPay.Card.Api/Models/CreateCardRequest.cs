using System.ComponentModel.DataAnnotations;

namespace UATPRapidPay.Card.Api.Models
{
    public class CreateCardRequest
    {
        [Required]
        public string Lastname { get; set; }
    }
}