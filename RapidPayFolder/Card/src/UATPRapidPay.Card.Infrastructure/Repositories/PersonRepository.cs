using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<Person> GetByIdAsync(Guid id)
        {
            return await _writeDbContext.Set<Person>().SingleOrDefaultAsync(i=>i.Id == id);
        }
    }
}