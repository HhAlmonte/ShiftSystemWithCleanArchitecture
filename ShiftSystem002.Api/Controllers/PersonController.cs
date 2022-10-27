using Microsoft.AspNetCore.Mvc;
using ShiftSystem002.Application.Interfaces;
using ShiftSystem002.Application.Person.Dto;
using ShiftSystem002.Application.Person.Handler;
using ShiftSystem002.Domain.Entities;

namespace ShiftSystem002.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonHandler _personHandler;
        private readonly IAzureFormRecognizedService _azureFormRecognized;

        public PersonController(IPersonHandler personHandler, IAzureFormRecognizedService azureFormRecognized)
        {
            _personHandler = personHandler;
            _azureFormRecognized = azureFormRecognized;
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
