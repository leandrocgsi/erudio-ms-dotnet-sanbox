using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace GreetingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {

        private volatile int count;

        [HttpGet]
        public IActionResult Get([FromQuery] string name = "World")
        {
            return Ok(new Greeting(IncrementAndGet(), $"Hello {name}"));
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}