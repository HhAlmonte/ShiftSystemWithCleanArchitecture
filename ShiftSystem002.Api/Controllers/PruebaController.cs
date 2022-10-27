using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShiftSystem002.Api.Controllers
{
    
    public class PruebaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hola mundo");
        }
    }
}