using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RapidPay.Logic;
using RapidPay.Models;
using System;
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
        readonly IPaymentLogic _paymentLogic;
        readonly ILogger<CardsController> _logger;
        public CardsController(ICardBalanceLogic cardBalanceLogic, IPaymentLogic paymentLogic, ILogger<CardsController> logger)
        {
            _cardBalanceLogic = cardBalanceLogic;
            _paymentLogic = paymentLogic;
            _logger = logger;
        }

        [HttpGet]
        [Route("Balance")]
        public async Task<IActionResult> GetBalanceAsync([FromQuery] GetBalanceRequest request)
        {
            var userId = HttpContext.User.Claims.First(a => a.Type == "Id");

            var balance = await _cardBalanceLogic.GetBalanceAsync(int.Parse(userId.Value), request.CardNumber, request.From, request.To);

            return Ok(balance);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCardRequest request)
        {
            var userId = HttpContext.User.Claims.First(a => a.Type == "Id");

            await _cardBalanceLogic.CreateAsync(int.Parse(userId.Value), request.Number, request.Limit);

            return Ok();
        }

        [HttpPost]
        [Route("{number}/pay")]
        public async Task<IActionResult> CreateAsync(string number, [FromBody] PayWithCardRequest request)
        {
            var userId = HttpContext.User.Claims.First(a => a.Type == "Id");

            await _paymentLogic.PayAsync(int.Parse(userId.Value), number, request.Amount);

            return Ok();
        }

        [HttpPost]
        [Route("{number}/paymultithreading")]
        public async Task<IActionResult> PayMultithreadingAsync(string number, [FromBody] PayWithCardRequest request)
        {
            var userId = HttpContext.User.Claims.First(a => a.Type == "Id");

            Parallel.For(1, 10, (a, b) =>
            {
                try
                {
                    _paymentLogic.PayMultithreading(int.Parse(userId.Value), number, request.Amount);
                }
                catch (Exception e)
                {
                    _logger.LogWarning(e, $"se ha producido una excepcion llamando, iteracion {a}");
                }
            });

            return Ok();
        }
    }
}