using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.CreateCard;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using System.Threading.Tasks;

namespace RapidPay.InterfaceAdapters.Presenters
{
    public class CreateCardPresenter : ICreateCardOutputPort, IPresenter<CardDTO>
    {
        public CardDTO Content { get; private set; }

        public Task HandleAsync(CardDTO createCardDTO)
        {
            Content = createCardDTO;

            return Task.CompletedTask;
        }
    }
}