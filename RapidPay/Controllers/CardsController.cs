using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Logic;
using RapidPay.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {
        readonly ICardBalanceLogic _cardBalanceLogic;
        public CardsController(ICardBalanceLogic cardBalanceLogic)
        {
            _cardBalanceLogic = cardBalanceLogic;
        }

        [HttpGet]
        [Route("Balance")]
        public async Task<IActionResult> GetBalance([FromQuery] GetBalanceRequest request)
        {
            var userId = HttpContext.User.Claims.First(a => a.Type == "Id");

            var balance = await _cardBalanceLogic.GetBalanceAsync(int.Parse(userId.Value), request.CardNumber, request.From, request.To);

            return Ok();
        }
    }
}