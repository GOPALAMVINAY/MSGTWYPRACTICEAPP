using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIRSTSERVICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        private readonly IHttpClientFactory _httpclient;

        public FirstController(IHttpClientFactory httpClient)
        {
            _httpclient = httpClient;
        }

        [HttpGet]
        [Route("Hello")]
        public ActionResult Hello()
        {
            return Ok("Hello from First Service");
        }
        [HttpGet]
        [Route("callgreetings")]
        public async Task<ActionResult> Greetings()
        {
            var httpClient = _httpclient.CreateClient();
            string response = await httpClient.GetStringAsync("https://localhost:7002/api/second/greetme");
            return Ok(response);
        }
    }
}
