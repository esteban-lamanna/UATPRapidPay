using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.GetAllCards
{
    public interface IGetAllCardsOutputPort
    {
        Task HandleAsync(IEnumerable<CardDTO> getAllDTO);
    }
}