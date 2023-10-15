using BuscarApi;
using System.Diagnostics;

namespace MauiApp1.View;

public partial class Partida : ContentPage
{

    private Stopwatch _stopwatch;
    private bool partidaCriada;
    private DadosPartida dadosPartida;

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

    public async void Alterar(object sender, EventArgs e)
    {
        PartidaAPI partidaAPI = new PartidaAPI();
        dadosPartida.PlacarTimeCasa = "2";
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