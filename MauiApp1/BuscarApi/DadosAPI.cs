using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MauiApp1
{
    public class DadosAPI
    {
        private readonly HttpClient _httpClient;

        public DadosAPI()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7070");


        }

        HttpClientHandler handler = new HttpClientHandler();
        public async Task<string> GetDadosAPI()
        {


            var response = await _httpClient.GetAsync($"api/Pelada/{5}");
            if (response.IsSuccessStatusCode)
            {
                string apiresult = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<DadosApi>(apiresult);
                Console.WriteLine(dados);
                return dados.Nome;
            }
            return $"Erro retorno";


        }

        public async Task<string> PostDados(DadosApi dadosApi)
        {

            var jsonDados = Newtonsoft.Json.JsonConvert.SerializeObject(dadosApi);
            var content = new StringContent(jsonDados, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/pelada", content);
            if (response.IsSuccessStatusCode)
            {
                string resposta = await response.Content.ReadAsStringAsync();
                return resposta;
            }
            else
            {
                return "erro";
            }
        }
    }
}


public class DadosApi
{
    public string Nome { get; set; }
    public DateTime Data { get; set; }
    public string CodigoPelada { get; set; }

}