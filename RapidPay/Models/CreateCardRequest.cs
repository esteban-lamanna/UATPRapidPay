using System.ComponentModel.DataAnnotations;

namespace InterfaceAdapters.RapidPay.Models
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