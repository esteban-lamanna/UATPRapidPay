using System.Threading.Tasks;

namespace RapidPay.Logic
{
    public interface IUserLoginLogic
    {
        Task<bool> Authenticate(string authUsername, string password);
    }
}