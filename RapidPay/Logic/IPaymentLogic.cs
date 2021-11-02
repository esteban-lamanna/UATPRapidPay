﻿using System.Threading.Tasks;

namespace RapidPay.Logic
{
    public interface IPaymentLogic
    {
        Task PayAsync(int idUser, string cardNumber, decimal amount);
        void PayMultithreadingAsync(int idUser, string cardNumber, decimal amount);
    }
}