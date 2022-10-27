using Microsoft.AspNetCore.Mvc;
using ShiftSystem002.Application.Person.Dto;
using ShiftSystem002.Application.Person.Handler;

namespace ShiftSystem002.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonHandler _personHandler;

        public PersonController(IPersonHandler personHandler)
        {
            _personHandler = personHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonDto personDto)
        {
            try
            {
                var person = await _personHandler.Create(personDto);
                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var peoples = await _personHandler.Get();

            if (peoples == null) return NoContent();

            return Ok(peoples);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _personHandler.GetById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }
    }
}
