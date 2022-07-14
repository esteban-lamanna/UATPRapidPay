using System;
using System.Threading.Tasks;
using UATPRapidPay.Card.Application.Services;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.Factories;
using UATPRapidPay.Card.Domain.ValueObjects;
using UATPRapidPay.Shared;
using UATPRapidPay.Shared.Commands;

namespace UATPRapidPay.Card.Application.Commands.Handlers
{
    internal sealed class CreateCardCommandHandler : ICommandHandler<CreateCardCommand>, ICommand
    {
        private readonly ICardFactory _cardFactory;
        private readonly ICardNumberFactory _cardNumberFactory;
        private readonly ICardService _cardService;
        Domain.Repositories.ICardRepository _cardRepository;

        public CreateCardCommandHandler(ICardFactory cardFactory,
                                        ICardService cardService,
                                        ICardNumberFactory cardNumberFactory,
                                        Domain.Repositories.ICardRepository cardRepository)
        {
            _cardFactory = cardFactory;
            _cardService = cardService;
            _cardNumberFactory = cardNumberFactory;
            _cardRepository = cardRepository;
        }

        public async Task HandleAsync(CreateCardCommand command)
        {
            var person = new Person(new Email(command.PersonEmail), new Name(command.PersonName));

            var cardNumber = await _cardNumberFactory.Generate(person);

            var expiryDate = DateTime.UtcNow.AddMonths(5);

            var dateExpirationDate = DateOnly.FromDateTime(expiryDate);

            var card = _cardFactory.Create(cardNumber, person, new ExpirationDate(dateExpirationDate), 100);

            await _cardRepository.CreateAsync(card);
        }
    }
}