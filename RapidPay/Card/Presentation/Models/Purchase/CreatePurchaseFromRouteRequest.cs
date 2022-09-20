using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UATPRapidPay.Card.Api.Models.Purchase
{
    public class CreatePurchaseFromRouteRequest
    {
        [FromRoute]
        [MinLength(16)]
        [MaxLength(16)]
        public string CardNumber { get; set; }
    }
}