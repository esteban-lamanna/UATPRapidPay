using Domain.RapidPay.DTO;
using System.Threading.Tasks;

namespace Domain.RapidPay.UseCasesPorts
{
    public interface ICreateCardOutputPort
    {
        Task HandleAsync(CardDTO createCardDTO);
    }
}