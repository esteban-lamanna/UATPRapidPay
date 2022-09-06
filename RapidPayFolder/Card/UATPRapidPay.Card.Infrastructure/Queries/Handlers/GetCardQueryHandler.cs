using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UATPRapidPay.Card.Application.DTO;
using UATPRapidPay.Card.Application.Queries;
using UATPRapidPay.Card.Infrastructure.EF;
using UATPRapidPay.Card.Infrastructure.Extensions;
using UATPRapidPay.Card.Infrastructure.Models;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Infrastructure.Queries.Handlers
{
    internal class GetCardQueryHandler : IQueryHandler<GetCardQuery, GetCardDTO>, IQuery
    {
        private readonly ReadDbContext _readDbContext;

        public GetCardQueryHandler(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public async Task<GetCardDTO> HandleAsync(GetCardQuery query)
        {
            var entity = _readDbContext.Set<ReadCardModel>().AsQueryable();

            if (query.Id.HasValue)
                entity = entity.Where(a => a.Id == query.Id);

            if (query.CardNumber != null)
                entity = entity.Where(a => a.Number == (string)query.CardNumber);

            return (await entity.SingleOrDefaultAsync())?.AsDto();
        }
    }
}