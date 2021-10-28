using RapidPay.Models;
using System;
using System.Threading.Tasks;

namespace RapidPay.Logic
{
    public interface ICardBalanceLogic
    {
        Task<GetBalanceResponse> GetBalanceAsync(int idUser, string cardNumber, DateTime from, DateTime to);
    }
}