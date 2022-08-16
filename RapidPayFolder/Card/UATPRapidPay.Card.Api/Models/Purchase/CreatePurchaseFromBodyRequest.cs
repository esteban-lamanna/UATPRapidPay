using System;
using System.ComponentModel.DataAnnotations;

namespace UATPRapidPay.Card.Api.Models.Purchase
{
    public class CreatePurchaseFromBodyRequest
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        [Attributes.NotEmpty]
        public Guid PurchaseId { get; set; }

        [Required]
        public string ProductName { get; set; }
    }
}