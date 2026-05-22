using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SECONDSERVICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecondController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClient;

        public SecondController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        [Route("greetme")]
        public ActionResult greetme()
        {
            return Ok("HELLO welcome secondSERVICE");
        }
        [HttpGet]
        [Route("callhello")]
        public async Task<ActionResult> callhello()
        {
            var http = _httpClient.CreateClient();
            string response = await http.GetStringAsync("https://localhost:7001/api/First/Hello");
            return Ok (response);
        }
    }
}
