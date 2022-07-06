using System.Collections.Generic;

namespace UATPRapidPay.Card.Infrastructure.Models
{
    public class ReadPersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ReadCardModel> Cards { get; set; }
    }
}