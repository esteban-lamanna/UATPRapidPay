﻿using RapidPay.Logic.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace RapidPay.Logic.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int IdUser { get; set; }
        public decimal Limit { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        public decimal GetAvailable(IEnumerable<Payment> payments)
        {
            if (payments == null)
                return Limit;

            return Limit - payments.Sum(a => a.Amount) - payments.Sum(a => a.Fee);
        }

        internal void ValidateLimit(decimal amount)
        {
            var available = GetAvailable(Payments);
            if (amount > available)
                throw new NoFundsException("Insuficient funds");
        }
    }
}