using System.ComponentModel.DataAnnotations;

namespace RapidPay.Drivers.UI.Models
{
    public class CreateCardRequest
    {
        [Required]
        [MaxLength(15)]
        [MinLength(15)]
        public string Number { get; set; }

        [Required]
        public decimal Limit { get; set; }
    }
}