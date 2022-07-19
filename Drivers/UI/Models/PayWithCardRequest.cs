using System.ComponentModel.DataAnnotations;
namespace RapidPay.Drivers.UI.Models
{
    public class PayWithCardRequest
    {
        [Required]
        public decimal Amount { get; set; }
    }
}