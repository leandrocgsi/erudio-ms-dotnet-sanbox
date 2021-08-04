using GreetingService.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Threading;

namespace GreetingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
{

        private volatile int count;
        public GreetingConfiguration _greetingConfiguration;
        public IConfiguration Configuration;

        public GreetingController(IOptions<GreetingConfiguration> options, IConfiguration configuration)
        {
            _greetingConfiguration = options.Value;
            Configuration = configuration;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] string name = "")
{
            if (string.IsNullOrEmpty(name)) name = Configuration.ToString();
            return Ok(new Greeting(IncrementAndGet(), $"Hello {name}"));
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}