using System;
using System.ComponentModel.DataAnnotations;
using UATPRapidPay.Card.Api.Attributes;
using UATPRapidPay.Card.Application.Commands;

namespace UATPRapidPay.Card.Api.Models.Card
{
    public class CreateCardRequest
    {
        [Required]
        [NotEmpty]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string PersonName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(300)]
        public string PersonEmail { get; set; }
    }

    internal static class CreateCardRequestExtensions
    {
        internal static CreateCardCommand ToCommand(this CreateCardRequest request)
        {
            return new CreateCardCommand()
            {
                Id = request.Id,
                PersonName = request.PersonName,
                PersonEmail = request.PersonEmail
            };
        }
    }
}