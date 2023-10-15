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
    public class PartidadaController : ControllerBase
    {
        private readonly IPartida _partida;
        private readonly IMapper _mapper;

        public PartidadaController(IPartida partida, IMapper mapper)
        {
            _partida = partida;
            _mapper = mapper;
        }





        // GET: api/<PartidadaController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<PartidadaController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<PartidadaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PartidaModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos");
            }

            var partida = _mapper.Map<Partidum>(model); 
            if(await _partida.Create(partida))
            {
                return Ok(partida);
            }
            return BadRequest("Algo de errado aconteceu");
        }

        //// PUT api/<PartidadaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PartidaModel model)
        {
            if(!ModelState.IsValid) { return BadRequest("Algum atributo esta invalido"); }

            var partida = _mapper.Map<Partidum>(model);
            partida.IdPartida = id;
            if(await _partida.Update(partida))
            {
                return Ok(partida);
            }
            return BadRequest("Algo deu errado");
        }

        //// DELETE api/<PartidadaController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
