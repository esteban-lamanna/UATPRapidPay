using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.ApplicationBusinessRules.UseCases.UseCasesPort.CreateCard;
using RapidPay.Drivers.UI.Models;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Requests;
using RapidPay.EnterpriseBusinessRules.Entities.DTO.Responses;
using RapidPay.InterfaceAdapters.Presenters;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Drivers.UI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("Cards")]
    public class CreateCardController : ControllerBase
    {
        private readonly ICreateCardInputPort _createCardInputPort;
        private readonly ICreateCardOutputPort _createCardOutputPort;

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