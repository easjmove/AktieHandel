using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AktieHandelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatNamesController : ControllerBase
    {
        // GET: api/<CatNamesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Garfield", "Felix" };
        }

            }
}
