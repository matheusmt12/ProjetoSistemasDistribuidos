using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BuscarApi
{


    public class Jogador
    {
        private readonly HttpClient _httpCliente;


        public Jogador()
        {
            _httpCliente = new HttpClient();
            _httpCliente.BaseAddress = new Uri("https://localhost:7070");
        }
       

        public async Task<string> PostDados(JogadorObject jogadorObject)
        {
            var jason = Newtonsoft.Json.JsonConvert.SerializeObject(jogadorObject);
            var contentStrig = new StringContent(jason, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpCliente.PostAsync("api/Jogador", contentStrig);

            if(response.IsSuccessStatusCode)
            {
                string resposta = await response.Content.ReadAsStringAsync();
                return resposta;
            }
            return "erro";
        }


    }



    public class JogadorObject
    {
        public string? NomeJogador { get; set; }
        public string? PosicaoJogador { get; set; }
        public string? UserName { get; set; }
        public string? Senha { get; set; }
    }
}