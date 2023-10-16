using APIPelada.Model;
using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
public class Sorteio
{
    private Random random; // Declare o objeto Random como um campo de classe

    public Sorteio()
    {
        random = new Random(); // Inicialize o objeto Random no construtor
    }
    public int SortearJogador(List<Listajogador> listaJogador)
    {
        int idJogador = 0, maxJogadores = listaJogador.Count();
        if (maxJogadores > 0)
        {
            idJogador = random.Next(0, maxJogadores);

        }

        return idJogador;
    }
}

namespace APIPelada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly IJogador _jogador;
        private readonly IListaJogador _lista;
        private readonly IPelada _pelada;
        private readonly ITime _time;
        private readonly IMapper _mapper;

        public TimeController(IJogador jogador, IListaJogador listaJogador, IPelada pelada, ITime time, IMapper mapper)
        {
            _jogador = jogador;
            _lista = listaJogador;
            _pelada = pelada;
            _time = time;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TimeModel model)
        {
            if (!ModelState.IsValid)
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
        [Route("CreateTeams/{idPelada}")]
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
            else
            {
                int isTimes = _time.GetQtdTimes(idPelada);
                Sorteio sorteio = new Sorteio();
                if (isTimes == 0)
                {
                    List<Listajogador> listaJogador = _lista.GetAllJogadores(idPelada).ToList();
                    int quantidadeDeTimes = listaJogador.Count() / pelada.QuantJogadorPorTime;
                    string nomeDosTimes = "ABCDEFGHIJKLMNOPQRSTUVXWYZ";

                    List<TimeJogadoreDTO> listaTime = new();
                    for (int i = 0; i < quantidadeDeTimes; i++)
                    {
                        Time time = new Time();
                        time.Nome = "Time " + nomeDosTimes[i];
                        time.Derrota = 0;
                        time.Vitorias = 0;
                        time.PeladaIdPelada = idPelada;
                        var timeCreate = _mapper.Map<Time>(time);
                        int idTime = await _time.Create(timeCreate);
                        TimeJogadoreDTO timeJogadore = new();
                        timeJogadore.NomeDoTime = time.Nome;

                        int qtdJogadorTime = pelada.QuantJogadorPorTime;
                        if (quantidadeDeTimes % 1 != 0 && i == 0)
                        {
                            qtdJogadorTime++;
                        }
                        for (int j = 0; j < qtdJogadorTime; j++)
                        {
                            int idSorteado = sorteio.SortearJogador(listaJogador);
                            Timejogador timeJogador = new();
                            timeJogador.JogadorIdJogador = listaJogador[idSorteado].JogadorIdJogador;
                            timeJogador.TimeIdTime = idTime;
                            await _time.CreateTime(timeJogador);
                            listaJogador.RemoveAt(idSorteado);
                            string nome = _jogador.GetNomeJogador(timeJogador.JogadorIdJogador);
                            timeJogadore.NomeDosJogadores.Add(nome);
                        }
                        listaTime.Add(timeJogadore);
                    }
                    return Ok(listaTime);
                }
                else
                {
                    var times = _time.GetTimes(idPelada);
                    List<Listajogador> listaJogador = _lista.GetAllJogadores(idPelada).ToList();
                    List<TimeJogadoreDTO> listaTime = new();
                    foreach (var t in times)
                    {
                        await _time.DeleteTime(t.IdTime);
                        int i = 0;
                        int qtdJogadorTime = pelada.QuantJogadorPorTime;
                        if (times.Count() % 1 != 0 && i == 0)
                        {
                            qtdJogadorTime++;
                        }
                        TimeJogadoreDTO timeJogadore = new();
                        timeJogadore.NomeDoTime = t.Nome;
                        for (int j = 0; j < qtdJogadorTime; j++)
                        {
                            int idSorteado = sorteio.SortearJogador(listaJogador);
                            Timejogador timeJogador = new();
                            timeJogador.JogadorIdJogador = listaJogador[idSorteado].JogadorIdJogador;
                            timeJogador.TimeIdTime = t.IdTime;
                            await _time.CreateTime(timeJogador);
                            listaJogador.RemoveAt(idSorteado);
                            string nome = _jogador.GetNomeJogador(timeJogador.JogadorIdJogador);
                            timeJogadore.NomeDosJogadores.Add(nome);

                        }
                        listaTime.Add(timeJogadore);
                    }


                    return Ok(listaTime);
                }


            }

        }

    }
}
