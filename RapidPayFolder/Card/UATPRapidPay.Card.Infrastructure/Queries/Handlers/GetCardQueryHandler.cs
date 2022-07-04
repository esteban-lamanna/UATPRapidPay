using System.Threading.Tasks;
using UATPRapidPay.Card.Application.DTO;
using UATPRapidPay.Card.Application.Queries;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Infrastructure.Queries.Handlers
{
    internal class GetCardQueryHandler : IQueryHandler<GetCardQuery, GetCardDTO>, IQuery
    {
        public Task<GetCardDTO> HandleAsync(GetCardQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}