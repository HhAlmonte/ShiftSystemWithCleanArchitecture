using Microsoft.AspNetCore.Mvc;
using ShiftSystem002.Application.PersonQueue.Dto;
using ShiftSystem002.Application.PersonQueue.Handler;

namespace ShiftSystem002.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonQueueController : ControllerBase
    {
        private readonly IPersonQueueHandler _personQueueHandler;

        public PersonQueueController(IPersonQueueHandler personQueueHandler)
        {
            _personQueueHandler = personQueueHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonQueueDto personQueueDto)
        {
            try
            {
                var personQueue = await _personQueueHandler.Create(personQueueDto);
                return Ok(personQueue);
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
            var personQueues = await _personQueueHandler.Get();

            if (personQueues == null) return NoContent();

            return Ok(personQueues);
        }

        [HttpGet("getNext/{id}")]
        public async Task<IActionResult> GetNext(int QueueId)
        {
            var personQueue = await _personQueueHandler.GetNext(QueueId);

            if (personQueue == null) return NoContent();

            await _personQueueHandler.UpdateStatusInPersonQueue(personQueue.Id, Domain.Enums.Status.Attended);
            
            return Ok(personQueue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var personQueue = await _personQueueHandler.GetById(id);

            if (personQueue == null) return NotFound();

            return Ok(personQueue);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonQueueDto personQueueDto)
        {
            try
            {
                var personQueue = await _personQueueHandler.Update(id, personQueueDto);
                return Ok(personQueue);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _personQueueHandler.Delete(id);
                return Ok($"PersonQueue with id: {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
