using System.ComponentModel.DataAnnotations;
namespace Presentation.RapidPay.Models
{
    public class PayWithCardRequest
    {
        [Required]
        public decimal Amount { get; set; }
    }
}