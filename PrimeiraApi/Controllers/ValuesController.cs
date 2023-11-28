using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApi.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("pegar-valores")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
