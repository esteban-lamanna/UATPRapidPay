using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UATPRapidPay.Card.Api.Models.Card
{
    public class CreateCardBodyRequest
    {
        [FromBody]
        [Required]
        public decimal Limit { get; set; }
    }
}