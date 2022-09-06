using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using UATPRapidPay.Card.Api.Attributes;

namespace UATPRapidPay.Card.Api.Models.Card
{
    public class CreateCardRouteRequest
    {
        [Required]
        [FromRoute]
        [NotEmpty]
        public Guid PersonId { get; set; }
    }
}