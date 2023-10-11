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
            return Ok("Sucesso");

        }
        [HttpGet("codigo/{codigo}")]
        public async Task<ActionResult> GetByCodPelada(string codigo)
        {
            var pelada = _pelada.GetPeladaByCod(codigo);
            if (pelada == null)
                return NotFound();
            return Ok(pelada);
        }
       
    }
}
