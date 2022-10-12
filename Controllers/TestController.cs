using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using la_metric.Models;
using System.Net.Http;

namespace la_metric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly string url = "https://la-funky.azurewebsites.net/api/sayHello?code=8rO-k3qgiDCde1YfJP8KnNZV1H-7l51u3bbZTuwvhUL0AzFu52Q9CA==";

        public TestController()
        {}

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var text = await response.Content.ReadAsStringAsync();

            return new OkObjectResult(text);
        }

    }
}