using System;

namespace UATPRapidPay.Card.Application.Exceptions
{
    public class PersonNotExistsException : ApplicationException
    {
        public PersonNotExistsException(Guid id) : base($"Person with id {id} doesn't exist.")
        {
        }
    }
}