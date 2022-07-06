using System;
using System.ComponentModel.DataAnnotations;

namespace UATPRapidPay.Card.Api.Models
{
    public class CreateCardRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string PersonName { get; set; }
    }
}