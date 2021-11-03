using System.ComponentModel.DataAnnotations;
namespace InterfaceAdapters.RapidPay.Models
{
    public class PayWithCardRequest
    {
        [Required]
        public decimal Amount { get; set; }
    }
}