using UATPRapidPay.Card.Application.DTO;
using UATPRapidPay.Card.Domain.ValueObjects;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Application.Queries
{
    public class GetCardQuery : IQuery<GetCardDTO>
    {
        public CardNumber CardNumber { get; set; }
    }
}