using Domain.RapidPay.Entities;
using System.Threading.Tasks;

namespace Domain.RapidPay.Logic
{
    public interface IUserLoginLogic
    {
        Task<User> Authenticate(string authUsername, string password);
    }
}