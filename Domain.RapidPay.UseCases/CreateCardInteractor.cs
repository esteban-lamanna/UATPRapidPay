using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.CreateCard;
using RapidPay.EnterpriseBusinessRules.Entities;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Requests;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using RapidPay.EnterpriseBusinessRules.Entities.Repositories;
using System.Threading.Tasks;

namespace RapidPay.ApplicationBusinessRules.UseCases
{
    public class CreateCardInteractor : ICreateCardInputPort
    {
        private readonly ICardRepository _cardRepository;
        private readonly ICreateCardOutputPort _createCardOutputPort;
        private readonly IUnitOfWork _unitOfWork;

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