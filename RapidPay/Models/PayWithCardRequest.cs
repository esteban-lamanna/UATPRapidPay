using System.ComponentModel.DataAnnotations;

namespace RapidPay.Models
{
    public class PayWithCardRequest
    {
        [Required]
        public decimal Amount { get; set; }
    }
}