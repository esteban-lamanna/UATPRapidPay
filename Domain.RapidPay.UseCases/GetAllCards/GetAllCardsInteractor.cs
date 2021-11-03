using Domain.RapidPay.DTO;
using Domain.RapidPay.UseCasesPorts;
using Drivers.RapidPay.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.RapidPay.UseCases
{
    public class GetAllCardsInteractor : IGetAllCardsInputPort
    {
        readonly ICardRepository _cardRepository;
        readonly IGetAllCardsOutputPort _getAllCardOutputPort;

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