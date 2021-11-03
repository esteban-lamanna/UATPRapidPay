using Domain.RapidPay.DTO;
using Domain.RapidPay.UseCasesPorts;
using InterfaceAdapters.RapidPay.Presenters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterfaceAdapters.RapidPay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllCardController
    {
        readonly IGetAllCardsInputPort _getAllCardInputPort;
        readonly IGetAllCardsOutputPort _getAllCardOutputPort;


        public GetAllCardController(IGetAllCardsInputPort getAllCardInputPort,
                                    IGetAllCardsOutputPort getAllCardOutputPort)
        {
            _getAllCardInputPort = getAllCardInputPort;
            _getAllCardOutputPort = getAllCardOutputPort;
        }

        public async Task<IEnumerable<CardDTO>> GetAllCards()
        {
            await _getAllCardInputPort.HandleAsync();

            return ((IPresenter<IEnumerable<CardDTO>>)_getAllCardOutputPort).Content;
        }
    }
}