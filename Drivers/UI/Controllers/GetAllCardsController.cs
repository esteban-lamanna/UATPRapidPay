using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.GetAllCards;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using RapidPay.InterfaceAdapters.Presenters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RapidPay.Drivers.UI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("Cards")]
    public class GetAllCardsController : ControllerBase
    {
        private readonly IGetAllCardsInputPort _getAllCardInputPort;
        private readonly IGetAllCardsOutputPort _getAllCardOutputPort;

        public GetAllCardsController(IGetAllCardsInputPort getAllCardInputPort,
                                    IGetAllCardsOutputPort getAllCardOutputPort)
        {
            _getAllCardInputPort = getAllCardInputPort;
            _getAllCardOutputPort = getAllCardOutputPort;
        }

        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            await _getAllCardInputPort.HandleAsync();

            IEnumerable<CardDTO> data = ((IPresenter<IEnumerable<CardDTO>>)_getAllCardOutputPort).Content;

            return Ok(data);
        }
    }
}