using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.GetAllCards;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using RapidPay.EnterpriseBusinessRules.Entities.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.ApplicationBusinessRules.UseCases
{
    public class GetAllCardsInteractor : IGetAllCardsInputPort
    {
        private readonly ICardRepository _cardRepository;
        private readonly IGetAllCardsOutputPort _getAllCardOutputPort;

        public GetAllCardsInteractor(ICardRepository cardRepository,
                                    IGetAllCardsOutputPort getAllCardsOutputPort)
        {
            _cardRepository = cardRepository;
            _getAllCardOutputPort = getAllCardsOutputPort;
        }

        public Task HandleAsync()
        {
            var products = _cardRepository.GetAll().Select(a =>
                    new CardDTO()
                    {
                        Id = a.Id,
                        Number = a.Number
                    }
            );

            _getAllCardOutputPort.HandleAsync(products);

            return Task.CompletedTask;
        }
    }
}