using BuscarApi;
using System.Diagnostics;

namespace MauiApp1.View;

public partial class Partida : ContentPage
{

    private Stopwatch _stopwatch;
    private bool partidaCriada;
    private DadosPartida dadosPartida;
    private int casa = 0,fora = 0;
    //private int fora
    public Partida()
    {
        dadosPartida = new DadosPartida();
        CriarPartida();
        partidaCriada = true;
        InitializeComponent();
    }

    public async void CriarPartida()
    {
        PartidaAPI partidaAPI = new PartidaAPI();
        dadosPartida = new DadosPartida
        {
            InicioPartida = false,
            PlacarTimeCasa = "0",
            PlacarTimeFora = "0",
            TempoDePartida = DateTime.Now,
            TimeIdTimeCasa = 1,
            TimeIdTimeFora = 2,
        };
        dadosPartida = await partidaAPI.PostPartida(dadosPartida);

        time1.Text = dadosPartida.TimeIdTimeCasa.ToString();
        time2.Text = dadosPartida.TimeIdTimeFora.ToString();
        placarT1.Text = dadosPartida.PlacarTimeCasa;
        placarT2.Text = dadosPartida.PlacarTimeFora;

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


}