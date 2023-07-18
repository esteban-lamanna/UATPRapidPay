using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UATPRapidPay.Person.Api.Models;
using UATPRapidPay.Shared.Queries;

namespace UATPRapidPay.Person.Api.Controllers.Person
{
    [ApiController]
    [Route("Person")]
    public class GetPersonController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public GetPersonController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [Route("{Id}", Name = "GetPersonById")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetPersonRequest getPersonRequest)
        {
            var personDto = await _queryDispatcher.QueryAsync(getPersonRequest.ToQuery());

            if (personDto == null)
                return NotFound();

            return Ok(personDto);
        }
    }
}