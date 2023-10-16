using BuscarApi;

namespace MauiApp1.View;

public partial class ListaJogador : ContentPage
{
    protected int idPelada;
    public ListaJogador(int idPelada)
    {
        this.idPelada = idPelada;
        InitializeComponent();
        TesteList();
    }
    private async void OnGenerateTeamsClicked(object sender, EventArgs e)
    {
        TimeAPI timeAPI = new TimeAPI();
        List<TimeJogadores> lista = new List<TimeJogadores>();
        lista = await timeAPI.GetTeamsAsync(this.idPelada);
        await Navigation.PushAsync(new ListaTimes(idPelada, lista));
    }


    public async void TesteList()
    {

        List<BuscarApi.ListaJogador> lista = new List<BuscarApi.ListaJogador>();

        Jogador jogador = new Jogador();

        lista = await jogador.GetAllJogadores();

        meuListView.ItemsSource = lista;
    }
}