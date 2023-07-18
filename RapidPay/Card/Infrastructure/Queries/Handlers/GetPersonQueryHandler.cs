using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UATPRapidPay.Card.Application.DTO;
using UATPRapidPay.Card.Application.Queries;
using UATPRapidPay.Card.Infrastructure.EF;
using UATPRapidPay.Card.Infrastructure.Models;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Card.Infrastructure.Queries.Handlers
{
    internal class GetPersonQueryHandler : IQueryHandler<GetPersonQuery, GetPersonDTO>, IQuery
    {
        private readonly ReadDbContext _readDbContext;

        public GetPersonQueryHandler(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public async Task<GetPersonDTO> HandleAsync(GetPersonQuery query)
        {
            var entity = await _readDbContext.Set<ReadPersonModel>()
                                             .SingleOrDefaultAsync(a => a.Id == query.Id);

            return entity?.AsDto();
        }
    }
}