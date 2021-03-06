using RapidPay.Logic.Exceptions;
using System.Collections.Generic;

namespace RapidPay.Logic.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int IdUser { get; set; }
        public decimal Limit { get; set; }
        public decimal Available { get; set; }
        public byte[] LastModification { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        internal void ValidateLimit(decimal amount)
        {
            if (amount > Available)
                throw new NoFundsException("Insuficient funds");
        }
    }
}