using System;
using System.ComponentModel.DataAnnotations;
using UATPRapidPay.Card.Api.Attributes;
using UATPRapidPay.Card.Application.Queries;

namespace UATPRapidPay.Person.Api.Models
{
    public class GetPersonRequest
    {
        [Required]
        [NotEmptyAttribute]
        public Guid Id { get; set; }
    }

    internal static class GetPersonRequestExtensions
    {
        internal static GetPersonQuery ToQuery(this GetPersonRequest request)
        {
            return new GetPersonQuery()
            {
                Id = request.Id,
            };
        }
    }
}