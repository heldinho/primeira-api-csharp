using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using PrimeiraApi.Model.Dto;
using PrimeiraApi.ViewModel;

namespace PrimeiraApi.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static HttpClient client = new HttpClient();

        [HttpPost]
        [Route("teste")]
        public IActionResult Add(ValuesViewModel values)
        {
            return Ok(values);
        }

        [HttpGet]
        [Route("posts")]
        public async Task<OkObjectResult> Get()
        {
            var json = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            return Ok(json);
        }
    }
}
