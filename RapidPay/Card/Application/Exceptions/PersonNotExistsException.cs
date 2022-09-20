using UATPRapidPay.Shared.Exceptions;

namespace UATPRapidPay.Card.Application.Exceptions
{
    public class PersonNotExistsException : ApplicationException
    {
        public PersonNotExistsException(System.Guid id) : base($"Person with id {id} doesn't exist.")
        {
        }
    }
}