using System.Threading.Tasks;

namespace RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.GetAllCards
{
    public interface IGetAllCardsInputPort
    {
        Task HandleAsync();
    }
}