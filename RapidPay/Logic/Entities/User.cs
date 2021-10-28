using System.Collections.Generic;

namespace RapidPay.Logic.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}