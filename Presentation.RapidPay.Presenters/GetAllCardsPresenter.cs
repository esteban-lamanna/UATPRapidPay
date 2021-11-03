using Domain.RapidPay.DTO;
using Domain.RapidPay.UseCasesPorts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceAdapters.RapidPay.Presenters
{
    public class GetAllCardsPresenter : IGetAllCardsOutputPort, IPresenter<IEnumerable<CardDTO>>
    {
        public IEnumerable<CardDTO> Content { get; private set; }

        public Task HandleAsync(IEnumerable<CardDTO> getAllDTO)
        {
            Content = getAllDTO;

            return Task.CompletedTask;
        }
    }
}