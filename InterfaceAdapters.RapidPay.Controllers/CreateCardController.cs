using Domain.RapidPay.DTO;
using Domain.RapidPay.UseCasesPorts;
using InterfaceAdapters.RapidPay.Presenters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InterfaceAdapters.RapidPay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateCardController
    {
        readonly ICreateCardInputPort _createCardInputPort;
        readonly ICreateCardOutputPort _createCardOutputPort;


        public CreateCardController(ICreateCardInputPort createCardInputPort,
                                    ICreateCardOutputPort createCardOutputPort)
        {
            _createCardInputPort = createCardInputPort;
            _createCardOutputPort = createCardOutputPort;
        }

        public async Task<CardDTO> CreateCard(CreateCardDTO dto)
        {
            await _createCardInputPort.HandleAsync(dto);

            return ((IPresenter<CardDTO>)_createCardOutputPort).Content;
        }
    }
}