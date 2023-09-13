using APIPelada.Model;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPelada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeladaController : ControllerBase
    {

        private readonly IPelada _pelada;
        private readonly IMapper _mapper;

        public PeladaController(IPelada pelada, IMapper mapper)
        {
            _pelada = pelada;
            _mapper = mapper;
        }



        // GET: api/<PeladaController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<PeladaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var pelada = await _pelada.Get(id);
            if(pelada == null)
                return NotFound();
            return Ok(pelada);
        }

        // POST api/<PeladaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PeladaModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Dados Inválidos");
            }
            var pelada = _mapper.Map<Peladum>(model);
            await _pelada.Create(pelada);
            return Ok();

        }

        // PUT api/<PeladaController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<PeladaController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
