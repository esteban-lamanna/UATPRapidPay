using System;

namespace RapidPay.Logic.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int IdCard { get; set; }
        public virtual Card Card { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public decimal Fee { get; set; }
    }
}