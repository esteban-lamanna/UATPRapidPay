using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Application.Exceptions;
using UATPRapidPay.Card.Domain.DomainEvents;
using UATPRapidPay.Card.Domain.Factories;
using UATPRapidPay.Card.Domain.Repositories;
using UATPRapidPay.Shared.Commands;
using UATPRapidPay.Shared.Services;

namespace UATPRapidPay.Card.Application.Commands.Handlers
{
    internal sealed class CreateCardCommandHandler : ICommandHandler<CreateCardCommand>, ICommand
    {
        private readonly ICardFactory _cardFactory;
        private readonly ICardRepository _cardRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IEventProcessor _eventProcessor;

        public CreateCardCommandHandler(ICardFactory cardFactory,
                                        ICardRepository cardRepository,
                                        IPersonRepository personRepository,
                                        IEventProcessor eventProcessor)
        {
            _cardFactory = cardFactory;
            _cardRepository = cardRepository;
            _personRepository = personRepository;
            _eventProcessor = eventProcessor;
        }

        public async Task HandleAsync(CreateCardCommand command)
        {
            var person = await _personRepository.GetByIdAsync(command.PersonId);

            if (person == null)
                throw new PersonNotExistsException(command.PersonId);

            var card = await _cardFactory.Create(command.CardId,
                                                 person,
                                                 command.Limit);

            await _cardRepository.CreateAsync(card);

            await _eventProcessor.ProcessAsync(card.Events);
        }
    }
}