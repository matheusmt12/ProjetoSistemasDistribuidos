using BuscarApi;

namespace MauiApp1.View;

public partial class ListaJogador : ContentPage
{
    protected int idPelada;
    protected string _codPartida;
    public ListaJogador(int idPelada, string codPartida)
    {
        this.idPelada = idPelada;
        InitializeComponent();

        _codPartida = codPartida;
        ListaJogadore();
    }
    private async void GerarTimes(object sender, EventArgs e)
    {
        TimeAPI timeAPI = new TimeAPI();
        List<TimeJogadores> lista = new List<TimeJogadores>();
        lista = await timeAPI.GetTeamsAsync(this.idPelada);
        await Navigation.PushAsync(new ListaTimes(idPelada, lista));
       
    }

	
    public async void ListaJogadore()
    {
        Jogador jogador = new Jogador();
        List<BuscarApi.ListaJogador> list = new List<BuscarApi.ListaJogador>();
        list = await jogador.GetAllJogadores(_codPartida);
        meuListView.ItemsSource = list;

    }


}