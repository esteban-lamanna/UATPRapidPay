using Microsoft.EntityFrameworkCore;
using RapidPay.Logic.Entities;
using RapidPay.Logic.Exceptions;
using RapidPay.Models;
using RapidPay.Repository;
using System;
using System.Threading.Tasks;

namespace RapidPay.Logic
{
    public class CardBalanceLogic : ICardBalanceLogic
    {
        readonly RapidPayContext _rapidPayContext;
        public CardBalanceLogic(RapidPayContext rapidPayContext)
        {
            _rapidPayContext = rapidPayContext;
        }

        public async Task<GetBalanceResponse> GetBalanceAsync(int idUser,
                                                              string cardNumber,
                                                              DateTime from,
                                                              DateTime to)
        {
            await ValidateCardNumberAsync(idUser, cardNumber);

            return new GetBalanceResponse();
        }

        private async Task ValidateCardNumberAsync(int idUser, string cardNumber)
        {
            var card = await _rapidPayContext.Set<Card>().AnyAsync(a => a.Number == cardNumber && a.IdUser == idUser);

            if (!card)
                throw new InvalidCardException("Invalid card number.");
        }
    }
}