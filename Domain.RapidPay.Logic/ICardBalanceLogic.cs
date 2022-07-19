using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using System;
using System.Threading.Tasks;

namespace RapidPay.ApplicationBusinessRules.UseCases.Logic
{
    public interface ICardBalanceLogic
    {
        Task<GetBalanceDTO> GetBalanceAsync(int idUser, string cardNumber, DateTime from, DateTime to);
        Task CreateAsync(int idUser, string cardNumber, decimal limit);
    }
}