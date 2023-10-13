using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        HttpClientHandler handler = new HttpClientHandler();
        public async Task<string> GetLogin(string username, string senha)
        {

            var response = await _httpCliente.GetAsync($"api/Login/{username},{senha}");
            if (response.IsSuccessStatusCode)
            {
                string apiresult = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<JogadorObject>(apiresult);
                Console.WriteLine(dados);
                if (dados.UserName.Equals(username) && dados.Senha.Equals(senha))
                {
                    return "Encontrado";
                }
                  
            }
            return $"Erro retorno";


        }

        public async Task<List<ListaJogador>> GetAllJogadores()
        {

            List<ListaJogador> list = new List<ListaJogador> ();
            var response = await _httpCliente.GetAsync("api/ListaJogador");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<ListaJogador>>(content);
                return list;
            }
            else
            {
                return null;
            }
            
        }

    }



    public class JogadorObject
    {
        public string? NomeJogador { get; set; }
        public string? PosicaoJogador { get; set; }
        public string? UserName { get; set; }
        public string? Senha { get; set; }
    }

    public class ListaJogador
    {
        public string? Nome { get; set; }
        public string? Posicao { get; set; }
    }
}