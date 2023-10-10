﻿using APIPelada.Mappers;
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
    public class JogadorController : ControllerBase
    {

        private readonly IJogador _jogador;
        private readonly IMapper _mapper;

        public JogadorController(IJogador jogador, IMapper mapper)
        {
            _mapper = mapper;
            _jogador = jogador;
        }




        // GET: api/<JogadorController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<JogadorController>/5
        [HttpGet("{userName},{senha}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JogadorController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] JogadorModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos");
            }
            var jogador = _mapper.Map<Jogador>(value);
            if (await _jogador.Create(jogador))
            {
                return Ok("Sucesso");
            }
            return BadRequest("Algo deu errado ");
        }

        //// PUT api/<JogadorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<JogadorController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
