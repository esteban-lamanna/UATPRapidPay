using RapidPay.EnterpriseBusinessRules.Entities.DTO.Requests;
using System.Threading.Tasks;

namespace RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.CreateCard
{
    public interface ICreateCardInputPort
    {
        Task HandleAsync(CreateCardDTO createCardDTO);
    }
}