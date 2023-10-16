using BuscarApi;

namespace MauiApp1.View;

public partial class ListaJogador : ContentPage
{

	private readonly string _codPartida;
	public ListaJogador(string codPartida)
	{
		_codPartida = codPartida;
        InitializeComponent();
        TesteList();
    }



    public async void TesteList()
	{
		
		List<BuscarApi.ListaJogador> lista = new List<BuscarApi.ListaJogador>();

		Jogador jogador = new Jogador();

		lista = await jogador.GetAllJogadores(_codPartida);

		meuListView.ItemsSource = lista;
	}
}