using APIPelada.Model;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPelada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly IListaJogador _lista;
        private readonly IPelada _pelada;
        private readonly ITime _time;
        private readonly IMapper _mapper;

        public TimeController(IListaJogador listaJogador,IPelada pelada,ITime time, IMapper mapper)
        {
            _lista = listaJogador;
            _pelada = pelada;
            _time = time;
            _mapper = mapper;
        }




        // GET: api/<TimeController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<TimeController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<TimeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TimeModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Dados inválido");
            }

            var time = _mapper.Map<Time>(model);
            var isTrue = await _time.Create(time);
            if (isTrue > 0)
            {
                return Ok("Sucesso");
            }
            return BadRequest("Algo deu errado");
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeams(int idPelada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválido");
            }
            var pelada = await _pelada.Get(idPelada);

            if (pelada == null)
            {
                return BadRequest("Pelada não encontrada");
            }
            else{
                int isTimes = await _time.GetQtdTimes(idPelada);

                if (isTimes == 0)
                {
                    int quantidadeDeTimes = pelada.Listajogadors.Count() / pelada.QuantJogadorPorTime;
                    string nomeDosTimes = "ABCDEFGHIJKLMNOPQRSTUVXWYZ";
                  
                    
                        for (int i = 0; i < quantidadeDeTimes; i++)
                        {
                            Time time = new Time();
                            time.Nome = "Time " + nomeDosTimes[i];
                            time.Derrota = 0;
                            time.Vitorias = 0;
                            var timeCreate = _mapper.Map<Time>(time);
                            int idTime = await _time.Create(timeCreate);

                            List<Listajogador>listaJogador = _lista.GetAllJogadores(idPelada).ToList();
                            int qtdJogadorTime = pelada.QuantJogadorPorTime;
                            if(quantidadeDeTimes % 1 != 0 && i == 0)
                            {
                               qtdJogadorTime++;
                            }
                            for(int j = 0; j < qtdJogadorTime; j++)
                            {
                                int idSorteado = SortearJogador(listaJogador);
                                Timejogador timeJogador = new();
                                timeJogador.JogadorIdJogador = listaJogador[idSorteado].JogadorIdJogador;
                                timeJogador.TimeIdTime = idTime;
                                await _time.CreateTime(timeJogador);
                                listaJogador.RemoveAt(idSorteado);
                            }
                            
                        }
                    return Ok("Sucesso");
                }
                else
                {
                    var times = _time.GetTimes(idPelada);
                    foreach (var t in times)
                    {
                        await _time.DeleteTime(t.IdTime);
                        int i = 0;
                        List<Listajogador> listaJogador = _lista.GetAllJogadores(idPelada).ToList();
                        int qtdJogadorTime = pelada.QuantJogadorPorTime;
                        if (times.Count() % 1 != 0 && i == 0)
                        {
                            qtdJogadorTime++;
                        }
                        for (int j = 0; j < qtdJogadorTime; j++)
                        {
                            int idSorteado = SortearJogador(listaJogador);
                            Timejogador timeJogador = new();
                            timeJogador.JogadorIdJogador = listaJogador[idSorteado].JogadorIdJogador;
                            timeJogador.TimeIdTime = t.IdTime;
                            await _time.CreateTime(timeJogador);
                            listaJogador.RemoveAt(idSorteado);
                        }
                    }
                    return Ok("Sucesso");
                }

               
            }
          


        }

        public int SortearJogador(List<Listajogador> listaJogador)
        {
            int idJogador = 0, maxJogadores = 0;
            Random random = new Random();
            if (maxJogadores > 0)
            {
                idJogador = random.Next(0, maxJogadores); 

            }
            
            return idJogador;
        }
    }
}
