using System.Collections.Generic;

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
    }
}