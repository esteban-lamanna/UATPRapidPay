using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.Repositories;
using UATPRapidPay.Card.Infrastructure.EF;

namespace UATPRapidPay.Card.Infrastructure.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        private readonly WriteDbContext _writeDbContext;
        public PersonRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public async Task CreateAsync(Person person)
        {
            _writeDbContext.Add(person);

            await _writeDbContext.SaveChangesAsync();
        }

        public Task<Person> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}