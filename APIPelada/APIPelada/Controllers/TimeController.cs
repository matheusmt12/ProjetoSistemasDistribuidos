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
    public class TimeController : ControllerBase
    {

        private readonly ITime _time;
        private readonly IMapper _mapper;

        public TimeController(ITime time, IMapper mapper)
        {
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

            if(await _time.Create(time))
            {
                return Ok("Sucesso");
            }
            return BadRequest("Algo deu errado");
        }

        //// PUT api/<TimeController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TimeController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
