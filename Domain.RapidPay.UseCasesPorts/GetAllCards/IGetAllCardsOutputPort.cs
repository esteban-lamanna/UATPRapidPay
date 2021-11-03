using Domain.RapidPay.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.RapidPay.UseCasesPorts
{
    public interface IGetAllCardsOutputPort
    {
        Task HandleAsync(IEnumerable<CardDTO> getAllDTO);
    }
}