using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Application.DTO;

namespace UATPRapidPay.Card.Application.Queries
{
    public class GetCardQueryHandler : IQueryHandler<GetCardQuery, GetCardDTO>
    {
        public Task<GetCardDTO> HandleAsync(GetCardQuery query)
        {
            throw new NotImplementedException();
        }
    }
}