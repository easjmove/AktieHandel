using AktieHandelLibrary;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AktieHandelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AktieHandelController : ControllerBase
    {
        private AktieHandelRepository _repository;

        public AktieHandelController(AktieHandelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<AktieHandel> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<AktieHandelController>/5
        [HttpGet("{id}")]
        public AktieHandel? Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/<AktieHandelController>
        [HttpPost]
        public AktieHandel Post([FromBody] AktieHandel value)
        {
            return _repository.Add(value);
        }

        // PUT api/<AktieHandelController>/5
        [HttpPut("{id}")]
        public AktieHandel? Put(int id, [FromBody] AktieHandel value)
        {
            return _repository.Update(id, value);
        }

        // DELETE api/<AktieHandelController>/5
        [HttpDelete("{id}")]
        public AktieHandel? Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
