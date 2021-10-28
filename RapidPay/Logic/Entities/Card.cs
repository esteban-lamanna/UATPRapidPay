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

        public decimal GetAvailable(IQueryable<Payment> payments)
        {
            if (payments == null)
                return Limit;

            return Limit - payments.Sum(a => a.Amount) - payments.Sum(a => a.Fee);
        }
    }
}