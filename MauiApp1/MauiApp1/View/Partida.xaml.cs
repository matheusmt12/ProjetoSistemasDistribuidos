using BuscarApi;
using System.Diagnostics;

namespace MauiApp1.View;

public partial class Partida : ContentPage
{

	private Stopwatch _stopwatch;
	public Partida()
	{
		CriarPartida();
		InitializeComponent();
	}

	public async void CriarPartida()
	{
		PartidaAPI partidaAPI = new PartidaAPI();
		DadosPartida dadosPartida = new DadosPartida
		{
			InicioPartida = false,
			PlacarTimeCasa = "0",
			PlacarTimeFora = "0",
			TempoDePartida = DateTime.Now,
			TimeIdTimeCasa = 1,
			TimeIdTimeFora = 2,
		};
		partidaAPI.PostPartida(dadosPartida);

		
		
	}


}