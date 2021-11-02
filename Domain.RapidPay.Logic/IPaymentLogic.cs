using System.Threading.Tasks;

namespace Domain.RapidPay.Logic
{
    public interface IPaymentLogic
    {
        Task PayAsync(int idUser, string cardNumber, decimal amount);
        void PayMultithreading(int idUser, string cardNumber, decimal amount);
    }
}