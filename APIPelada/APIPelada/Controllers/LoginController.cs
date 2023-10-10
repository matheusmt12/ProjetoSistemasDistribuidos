using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPelada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IJogador _jogador;
        private readonly IMapper _mapper;
        public LoginController(IJogador jogador, IMapper mapper)
        {
            _jogador = jogador;
            _mapper = mapper;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{username},{password}")]
        public async Task<ActionResult> Get(string username, string password)
        {
            var jogador = _jogador.Login(username, password);
            if (jogador == null)
                return NotFound("Login ou senha errada");
            return Ok(jogador);

        }

    }
}
