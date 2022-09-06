using System;
using System.Collections.Generic;
using UATPRapidPay.Card.Application.DTO;

namespace UATPRapidPay.Card.Infrastructure.Models
{
    public class ReadPersonModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        internal GetPersonDTO AsDto()
        {
            return new GetPersonDTO()
            {
                Id = Id,
                Name = Name,
            };
        }
    }
}