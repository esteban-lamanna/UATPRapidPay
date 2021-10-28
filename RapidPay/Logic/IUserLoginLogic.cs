using RapidPay.Logic.Entities;
using System.Threading.Tasks;

namespace RapidPay.Logic
{
    public interface IUserLoginLogic
    {
        Task<User> Authenticate(string authUsername, string password);
    }
}