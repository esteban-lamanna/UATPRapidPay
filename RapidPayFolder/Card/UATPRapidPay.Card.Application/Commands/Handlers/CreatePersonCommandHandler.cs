using System.Threading.Tasks;
using UATPRapidPay.Card.Domain.Factories;
using UATPRapidPay.Card.Domain.Repositories;
using UATPRapidPay.Shared.Commands;

namespace UATPRapidPay.Card.Application.Commands.Handlers
{
    internal sealed class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand>, ICommand
    {
        private readonly IPersonFactory _personFactory;
        private readonly IPersonRepository _personRepository;

        public CreatePersonCommandHandler(IPersonFactory personFactory,
                                          IPersonRepository personRepository)
        {
            _personFactory = personFactory;
            _personRepository = personRepository;
        }

        public async Task HandleAsync(CreatePersonCommand command)
        {
            var person = await _personFactory.GenerateAsync(command.Id,
                                                            command.Name,
                                                            command.Email);

            await _personRepository.CreateAsync(person);
        }
    }
}