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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<AktieHandel>> GetAll()
        {
            List<AktieHandel> aktieHandler = _repository.GetAll();
            if (aktieHandler == null || aktieHandler.Count == 0)
            {
                return NotFound();
            }
            return Ok(_repository.GetAll());
        }

        // GET api/<AktieHandelController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AktieHandel> GetById(int id)
        {
            AktieHandel? aktieHandel = _repository.GetById(id);
            if (aktieHandel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_repository.GetById(id));
            }
        }

        // POST api/<AktieHandelController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<AktieHandel> Post([FromBody] AktieHandelDTO value)
        {
            try
            {
                AktieHandel newAktie = AktieHandelDTOHelper.ToClass(value);
                newAktie = _repository.Add(newAktie);
                //return CreatedAtAction(nameof(GetById), new { id = newAktie.Id }, newAktie);
                return Created($"/api/AktieHandel/{newAktie.Id}", newAktie);
            } catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
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
