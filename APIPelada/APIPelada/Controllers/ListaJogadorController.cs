using APIPelada.Mappers;
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
    public class ListaJogadorController : ControllerBase
    {

        private readonly IListaJogador _listaJogador;
        private readonly IMapper _mapper;

        public ListaJogadorController(IListaJogador listaJogador, IMapper mapper)
        {
            _listaJogador = listaJogador;
            _mapper = mapper;
        }



        // GET: api/<ListaJogadorController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ListaJogadorController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ListaJogadorController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ListaJogadorModel listaJogadorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos");
            }

            var idPelada =  _listaJogador.GetIdPelada(listaJogadorModel.CodigoTorneio);
            var jogadores = _mapper.Map<Listajogador>(listaJogadorModel);
            jogadores.PeladaIdPelada = idPelada;
            if(await _listaJogador.Create(jogadores))
            {
                return Ok("Sucesso"); 
            }
            return BadRequest("Algo de errado aconteceu");
            
        }

        //// PUT api/<ListaJogadorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ListaJogadorController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
