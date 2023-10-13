using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BuscarApi;
using Newtonsoft.Json;


namespace MauiApp1
{
    public class PeladaAPI
    {
        private readonly HttpClient _httpClient;

        public PeladaAPI()
        {

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7070");


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

        public async Task<int> GetPeladaByCod(string codigo)
        {
            var response = await _httpClient.GetAsync($"api/Pelada/Codigo/{codigo}");
            if (response.IsSuccessStatusCode)
            {
                string apiresult = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<int>(apiresult);
                Console.WriteLine(dados);
                return dados;
             
            }
            return 0;

        }

        public async Task<string> InsertJogadorInPelada(ListaJogadorId listaJogador)
        {
            var jsonDados = Newtonsoft.Json.JsonConvert.SerializeObject(listaJogador);
            var content = new StringContent(jsonDados, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/ListaJogador", content);
            if (response.IsSuccessStatusCode)
            {
                var resposta = await response.Content.ReadAsStringAsync();
                return resposta;
            }
            return "Problema";
        }
    }
}
public class ListaJogadorId
{
    public int jogadorIdJogador { get; set; }
    public int peladaIdPelada { get; set; }
}

public class DadosApi
{
    public string Nome { get; set; }
    public DateTime? Data { get; set; }
    public string CodigoPelada { get; set; }
    public string Local { get; set; }

}