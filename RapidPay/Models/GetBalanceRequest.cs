using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation.RapidPay.Models
{
    public class GetBalanceRequest
    {
        [Required]
        [MaxLength(15)]
        [MinLength(15)]
        public string CardNumber { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }
    }
}