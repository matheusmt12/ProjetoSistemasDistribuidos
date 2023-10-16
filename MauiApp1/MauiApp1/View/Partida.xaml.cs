using BuscarApi;
using System.Diagnostics;


namespace MauiApp1.View;

public partial class Partida : ContentPage
{

    private Stopwatch _stopwatch;
    private bool partidaCriada;
    private DadosPartida dadosPartida;
    private List<TimeJogadores>  lista = new List<TimeJogadores>();
    private int casa = 0,fora = 0;
    //private int fora
    public Partida(List<TimeJogadores> lista)
    {
        dadosPartida = new DadosPartida();
        lista = lista;
        CriarPartida();
        partidaCriada = true;
        InitializeComponent();
    }

    public int Sortear (int count)
    {
        Random random = new Random();

        return random.Next(count + 1 );

    }
    
    public async void CriarPartida()
    {
        Stack<int> array = new Stack<int>();
        int antCasa = 0;
        int antFora = 0;
        foreach (var item in lista)
        {
            int sorteio = Sortear(lista.Count());
            while (!array.Contains(sorteio))
            {
                array.Push(sorteio);
            }
        }
        
        PartidaAPI partidaAPI = new PartidaAPI();
        dadosPartida = new DadosPartida
        {
            InicioPartida = false,
            PlacarTimeCasa = "0",
            PlacarTimeFora = "0",
            TempoDePartida = DateTime.Now,
            TimeIdTimeCasa = casa,
            TimeIdTimeFora = fora,
        };
        dadosPartida = await partidaAPI.PostPartida(dadosPartida);
        Device.BeginInvokeOnMainThread(() =>
        {
            time1.Text = dadosPartida.TimeIdTimeCasa.ToString();
            time2.Text = dadosPartida.TimeIdTimeFora.ToString();
            placarT1.Text = dadosPartida.PlacarTimeCasa;
            placarT2.Text = dadosPartida.PlacarTimeFora;
        });

    }

    public async void Casa(object sender, EventArgs e)
    {
        PartidaAPI partidaAPI = new PartidaAPI();
        casa += 1;
        dadosPartida.PlacarTimeCasa = (string)casa.ToString();
        await partidaAPI.PutPartida(dadosPartida);

        Device.BeginInvokeOnMainThread(() =>
        {
            time1.Text = dadosPartida.TimeIdTimeCasa.ToString();
            time2.Text = dadosPartida.TimeIdTimeFora.ToString();
            placarT1.Text = dadosPartida.PlacarTimeCasa;
            placarT2.Text = dadosPartida.PlacarTimeFora;
        });
    }

    public async void Fora(object sender, EventArgs e)
    {
        PartidaAPI partidaAPI = new PartidaAPI();
        fora += 1;
        dadosPartida.PlacarTimeFora =(string)fora.ToString();
        await partidaAPI.PutPartida(dadosPartida);

        Device.BeginInvokeOnMainThread(() =>
        {
            time1.Text = dadosPartida.TimeIdTimeCasa.ToString();
            time2.Text = dadosPartida.TimeIdTimeFora.ToString();
            placarT1.Text = dadosPartida.PlacarTimeCasa;
            placarT2.Text = dadosPartida.PlacarTimeFora;
        });
    }

    /*
     
     placarT1 > placarT2
     
     
     */

}