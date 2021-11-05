using Domain.RapidPay.DTO;
using Domain.RapidPay.UseCasesPorts;
using InterfaceAdapters.RapidPay.Presenters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Drivers.RapidPay.UI
{
    [ApiController]
    [Authorize]
    [Route("Cards")]
    public class GetAllCardsController : ControllerBase
    {
        readonly IGetAllCardsInputPort _getAllCardInputPort;
        readonly IGetAllCardsOutputPort _getAllCardOutputPort;

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

            var data = ((IPresenter<IEnumerable<CardDTO>>)_getAllCardOutputPort).Content;

            return Ok(data);
        }
    }
}