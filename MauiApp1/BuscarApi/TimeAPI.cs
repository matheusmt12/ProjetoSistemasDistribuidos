using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuscarApi
{
    public class TimeJogadores
    {
        public int? idTime {  get; set; }
        public string? nomeDoTime { get; set; }
        public List<string>? nomeDosJogadores { get; set; }
    }
    public class TimeAPI
    {
        private readonly HttpClient _httpCliente;

        public TimeAPI()
        {
            _httpCliente = new HttpClient();
            _httpCliente.BaseAddress = new Uri("https://localhost:7070");
        }

        public async Task<List<TimeJogadores>> GetTeamsAsync(int idPelada)
        {
            try
            {

                var response = await _httpCliente.GetAsync($"api/Time/CreateTeams/{idPelada}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var times = JsonConvert.DeserializeObject<List<TimeJogadores>>(content);
                    return times;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Lida com erros de comunicação ou exceções
                return null;
            }
        }
    }
}
