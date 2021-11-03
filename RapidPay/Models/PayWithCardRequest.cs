using System.ComponentModel.DataAnnotations;
namespace Drivers.RapidPay.Models
{
    public class PayWithCardRequest
    {
        [Required]
        public decimal Amount { get; set; }
    }
}