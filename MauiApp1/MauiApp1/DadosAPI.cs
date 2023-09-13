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


        public async Task<string> GetDadosAPI()
        {
            HttpClientHandler handler = new HttpClientHandler();    

            var response = await _httpClient.GetAsync("api/Pelada/1");
                if (response.IsSuccessStatusCode)
                {
                    string apiresult = await response.Content.ReadAsStringAsync();
                    var dados = JsonConvert.DeserializeObject<DadosApi>(apiresult);
                return dados.Data.ToString();
            }
            return $"Erro retorno";


        }
    }
}

public class DadosApi
{
    public int idPelada { get; set; }
    public string Nome { get; set; }
    public DateTime Data { get; set; }
    public string CodigoPelada { get; set; }

}