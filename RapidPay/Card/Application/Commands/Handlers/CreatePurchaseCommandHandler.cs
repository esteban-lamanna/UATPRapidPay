using System.Threading.Tasks;
using UATPRapidPay.Card.Application.Exceptions;
using UATPRapidPay.Card.Domain.Entities;
using UATPRapidPay.Card.Domain.Repositories;
using UATPRapidPay.Card.Domain.ValueObjects;
using UATPRapidPay.Shared.Commands;
using UATPRapidPay.Shared.Services;

namespace UATPRapidPay.Card.Application.Commands.Handlers
{
    internal sealed class CreatePurchaseCommandHandler : ICommandHandler<CreatePurchaseCommand>, ICommand
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IEventProcessor _eventProcessor;
        object _purchaseLock = new();

        public CreatePurchaseCommandHandler(IPurchaseRepository purchaseRepository,
                                            ICardRepository cardRepository,
                                            IEventProcessor eventProcessor)
        {
            _purchaseRepository = purchaseRepository;
            _cardRepository = cardRepository;
            _eventProcessor = eventProcessor;
        }

        public async Task HandleAsync(CreatePurchaseCommand command)
        {
            var card = await _cardRepository.GetByNumberAsync(command.CardNumber);

            if (card == null)
                throw new CardDoesntExistException(command.CardNumber);

            var price = (Price)command.Price;

            var purchase = Purchase.Create(command.PurchaseId,card, price, (ProductName)command.ProductName);

            lock (_purchaseLock)
            {
                if (!card.HasAvailableFunds(price))
                {
                    throw new InsufficientFundsException();
                }

                card.UpdateLimit(purchase);

                _purchaseRepository.CreateAsync(purchase).GetAwaiter().GetResult();
            }

            await _eventProcessor.ProcessAsync(purchase.Events);
        }
    }
}