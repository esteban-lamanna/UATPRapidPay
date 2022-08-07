using System;
using System.ComponentModel.DataAnnotations;
using UATPRapidPay.Card.Api.Attributes;
using UATPRapidPay.Card.Application.Commands;

namespace UATPRapidPay.Card.Api.Models.Person
{
    public class CreatePersonRequest
    {
        [Required]
        [NotEmpty]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(300)]
        public string Email { get; set; }
    }

    internal static class CreatePersonRequestExtensions
    {
        internal static CreatePersonCommand ToCommand(this CreatePersonRequest request)
        {
            return new CreatePersonCommand()
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email
            };
        }
    }
}