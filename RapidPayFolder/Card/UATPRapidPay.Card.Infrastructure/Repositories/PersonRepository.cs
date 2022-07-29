using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.Repositories;

namespace UATPRapidPay.Card.Infrastructure.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        public Task CreateAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}