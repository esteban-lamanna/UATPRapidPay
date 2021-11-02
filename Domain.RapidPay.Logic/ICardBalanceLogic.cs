using Domain.RapidPay.DTO;
using System;
using System.Threading.Tasks;

namespace Domain.RapidPay.Logic
{
    public interface ICardBalanceLogic
    {
        Task<GetBalanceDTO> GetBalanceAsync(int idUser, string cardNumber, DateTime from, DateTime to);
        Task CreateAsync(int idUser, string cardNumber, decimal limit);
    }
}