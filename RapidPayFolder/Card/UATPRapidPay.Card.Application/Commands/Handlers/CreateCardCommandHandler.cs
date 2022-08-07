using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Application.Exceptions;
using UATPRapidPay.Card.Application.Services;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.Factories;
using UATPRapidPay.Card.Domain.Repositories;
using UATPRapidPay.Card.Domain.ValueObjects;
using UATPRapidPay.Shared;
using UATPRapidPay.Shared.Commands;

namespace UATPRapidPay.Card.Application.Commands.Handlers
{
    internal sealed class CreateCardCommandHandler : ICommandHandler<CreateCardCommand>, ICommand
    {
        private readonly ICardFactory _cardFactory;
        private readonly ICardNumberFactory _cardNumberFactory;
        private readonly ICardRepository _cardRepository;
        private readonly IPersonRepository _personRepository;

        public CreateCardCommandHandler(ICardFactory cardFactory,
                                        ICardNumberFactory cardNumberFactory,
                                        ICardRepository cardRepository,
                                        IPersonRepository personRepository)
        {
            _cardFactory = cardFactory;
            _cardNumberFactory = cardNumberFactory;
            _cardRepository = cardRepository;
            _personRepository = personRepository;
        }

        public async Task HandleAsync(CreateCardCommand command)
        {
            var person = await _personRepository.GetByIdAsync(command.PersonId);

            if (person == null)
                throw new PersonNotExistsException(command.PersonId);

            var cardNumber = await _cardNumberFactory.Generate(person);

            var expiryDate = DateTime.UtcNow.AddMonths(5);

            var dateExpirationDate = DateOnly.FromDateTime(expiryDate);

            var card = _cardFactory.Create(command.Id,
                                           cardNumber,
                                           person,
                                           new ExpirationDate(dateExpirationDate),
                                           command.Limit);

            await _cardRepository.CreateAsync(card);
        }
    }
}