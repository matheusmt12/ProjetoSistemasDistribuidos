using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscarApi
{
    public class PartidaAPI
    {
        private readonly HttpClient _httpClient;
        public PartidaAPI()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7070");
        }

        public async Task<DadosPartida> PostPartida(DadosPartida partida)
        {
            var jason = Newtonsoft.Json.JsonConvert.SerializeObject(partida);
            var content = new StringContent(jason, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Partidada", content);
            string resposta = await response.Content.ReadAsStringAsync();
            DadosPartida respostaReceive = Newtonsoft.Json.JsonConvert.DeserializeObject<DadosPartida>(resposta);
            if (response.IsSuccessStatusCode)
            {
                return respostaReceive;
            }
            return null;
        }

    }



    public class DadosPartida
    {
        public int IdPartida { get; set; }
        public string PlacarTimeCasa { get; set; } = string.Empty;
        public string PlacarTimeFora { get; set; } = string.Empty;
        public int TimeIdTimeFora { get; set; }
        public int TimeIdTimeCasa { get; set; }
        public DateTime TempoDePartida { get; set; }
        public bool? InicioPartida { get; set; }
    }
}
