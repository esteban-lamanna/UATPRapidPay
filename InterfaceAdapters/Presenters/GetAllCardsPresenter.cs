using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.GetAllCards;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RapidPay.InterfaceAdapters.Presenters
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