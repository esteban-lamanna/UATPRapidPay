using System;
using UATPRapidPay.Card.Application.DTO;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Application.Queries
{
    public class GetPersonQuery : IQuery<GetPersonDTO>
    {
        public Guid Id { get; set; }
    }
}