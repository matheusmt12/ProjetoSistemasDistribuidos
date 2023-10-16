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
    }
    private async void OnGenerateTeamsClicked(object sender, EventArgs e)
    {
        TimeAPI timeAPI = new TimeAPI();
        List<TimeJogadores> lista = new List<TimeJogadores>();
        lista = await timeAPI.GetTeamsAsync(this.idPelada);
        await Navigation.PushAsync(new ListaTimes(idPelada, lista));
    }

}