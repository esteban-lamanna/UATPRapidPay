using System.Threading.Tasks;

namespace Domain.RapidPay.UseCasesPorts
{
    public interface IGetAllCardsInputPort
    {
        Task HandleAsync();
    }
}