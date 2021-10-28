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

        public async Task CreateAsync(int idUser, string cardNumber, decimal limit)
        {
            if (await IsCardNumberInUseAsync(idUser, cardNumber))
                throw new CardNumberInUseException("Card number in use.");

            var card = new Card()
            {
                Limit = limit,
                IdUser = idUser,
                Number = cardNumber,
            };

            _rapidPayContext.Attach(card);

            await _rapidPayContext.SaveChangesAsync();
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
            bool exists = await IsCardNumberInUseAsync(idUser, cardNumber);

            if (!exists)
                throw new InvalidCardException("Invalid card number.");
        }

        private async Task<bool> IsCardNumberInUseAsync(int idUser, string cardNumber)
        {
            return await _rapidPayContext.Set<Card>().AnyAsync(a => a.Number == cardNumber && a.IdUser == idUser);
        }
    }
}