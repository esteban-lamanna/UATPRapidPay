using Shouldly;
using UATPRapidPay.Card.Domain.Exceptions;
using UATPRapidPay.Card.Domain.ValueObjects;

namespace UATPRapidPay.Card.Domain.Tests
{
    public class EmailShould
    {
        [Theory]
        [InlineData("esteban@hotmail.com", true)]
        [InlineData("@hotmail.com", false)]
        [InlineData("@.com", false)]
        [InlineData(" @.com", false)]
        [InlineData("esteban.com", false)]
        [InlineData("esteban.comsadasdsadsd", false)]
        public void ReturnValidEmail(string emailValue, bool valid)
        {
            //act
            var action = () =>
            {
                var email = new Email(emailValue);
                return email;
            };

            //assert
            if (valid)
            {
                var email = action();
                email.ShouldNotBeNull();
                email.Value.ShouldBe(emailValue);
            }
            else
            {
                action.ShouldThrow<EmailFormatException>();
            }
        }
    }
}