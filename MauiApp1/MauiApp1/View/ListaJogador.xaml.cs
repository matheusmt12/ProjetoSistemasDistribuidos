using BuscarApi;

namespace MauiApp1.View;

public partial class ListaJogador : ContentPage
{
	public ListaJogador()
	{
        TesteList();
        InitializeComponent();
	}



    public async void TesteList()
	{
		
		List<BuscarApi.ListaJogador> lista = new List<BuscarApi.ListaJogador>();

		Jogador jogador = new Jogador();

		lista = await jogador.GetAllJogadores();

		meuListView.ItemsSource = lista;
	}
}