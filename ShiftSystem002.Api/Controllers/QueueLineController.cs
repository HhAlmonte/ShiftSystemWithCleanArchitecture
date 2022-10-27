using Microsoft.AspNetCore.Mvc;
using ShiftSystem002.Application.QueueLine.Dto;
using ShiftSystem002.Application.QueueLine.Handler;

namespace ShiftSystem002.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueLineController : ControllerBase
    {
        private readonly IQueueLineHandler _queueLineHandler;

        public QueueLineController(IQueueLineHandler queueLineHandler)
        {
            _queueLineHandler = queueLineHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QueueLineDto queueLineDto)
        {
            try
            {
                var queueLine = await _queueLineHandler.Create(queueLineDto);
                return Ok(queueLine);
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
            var queueLines = await _queueLineHandler.Get();

            if (queueLines == null) return NoContent();

            return Ok(queueLines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var queueLine = await _queueLineHandler.GetById(id);

            if (queueLine == null) return NotFound();

            return Ok(queueLine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] QueueLineDto queueLineDto)
        {
            try
            {
                var queueLine = await _queueLineHandler.Update(id, queueLineDto);
                return Ok(queueLine);
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
                await _queueLineHandler.Delete(id);
                return Ok($"QueueLine with id: {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
