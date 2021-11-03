using Domain.RapidPay.DTO;
using Domain.RapidPay.Entities;
using Domain.RapidPay.UseCasesPorts;
using Drivers.RapidPay.Repository;
using System.Threading.Tasks;

namespace Domain.RapidPay.UseCases
{
    public class CreateCardInteractor : ICreateCardInputPort
    {
        readonly ICardRepository _cardRepository;
        readonly ICreateCardOutputPort _createCardOutputPort;
        readonly IUnitOfWork _unitOfWork;

        public CreateCardInteractor(ICardRepository cardRepository,
                                    ICreateCardOutputPort createCardOutputPort,
                                    IUnitOfWork unitOfWork)
        {
            _cardRepository = cardRepository;
            _createCardOutputPort = createCardOutputPort;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(CreateCardDTO createCardDTO)
        {
            var card = new Card()
            {
                Available = createCardDTO.Limit,
                Number = createCardDTO.Number,
                Limit = createCardDTO.Limit,
                IdUser = createCardDTO.IdUser
            };

            _cardRepository.Create(card);

            await _unitOfWork.SaveAsync();

            await _createCardOutputPort.HandleAsync(new CardDTO()
            {
                Id = card.Id
            });
        }
    }
}