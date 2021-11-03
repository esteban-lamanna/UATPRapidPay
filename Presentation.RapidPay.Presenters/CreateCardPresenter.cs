using Domain.RapidPay.DTO;
using Domain.RapidPay.UseCasesPorts;
using System.Threading.Tasks;

namespace InterfaceAdapters.RapidPay.Presenters
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