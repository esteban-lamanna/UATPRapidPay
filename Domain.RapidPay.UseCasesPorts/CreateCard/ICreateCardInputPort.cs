using Domain.RapidPay.DTO;
using System.Threading.Tasks;

namespace Domain.RapidPay.UseCasesPorts
{
    public interface ICreateCardInputPort
    {
        Task HandleAsync(CreateCardDTO createCardDTO);
    }
}