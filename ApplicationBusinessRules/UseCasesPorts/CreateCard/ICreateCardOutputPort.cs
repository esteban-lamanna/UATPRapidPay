using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using System.Threading.Tasks;

namespace RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.CreateCard
{
    public interface ICreateCardOutputPort
    {
        Task HandleAsync(CardDTO createCardDTO);
    }
}