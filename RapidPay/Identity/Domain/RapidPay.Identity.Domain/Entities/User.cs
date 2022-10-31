using UATPRapidPay.Shared.Entities;

namespace RapidPay.Identity.Domain.Entities
{
    public class User : AggregateRoot<Guid>
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<string> Permissions { get; set; }
    }
}