using Domain.RapidPay.DTO;
using Domain.RapidPay.UseCasesPorts;
using Drivers.RapidPay.Models;
using InterfaceAdapters.RapidPay.Presenters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Drivers.RapidPay.UI
{
    [ApiController]
    [Authorize]
    [Route("Cards")]
    public class CreateCardController : ControllerBase
    {
        readonly ICreateCardInputPort _createCardInputPort;
        readonly ICreateCardOutputPort _createCardOutputPort;

        public CreateCardController(ICreateCardInputPort createCardInputPort,
                                    ICreateCardOutputPort createCardOutputPort)
        {
            _createCardInputPort = createCardInputPort;
            _createCardOutputPort = createCardOutputPort;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCardRequest request)
        {
            var userId = HttpContext.User.Claims.First(a => a.Type == "Id");

            var createCardDTO = new CreateCardDTO()
            {
                IdUser = int.Parse(userId.Value),
                Limit = request.Limit,
                Number = request.Number
            };

            await _createCardInputPort.HandleAsync(createCardDTO);

            var output = ((IPresenter<CardDTO>)_createCardOutputPort).Content;

            return Ok();
        }
    }
}