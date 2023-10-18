namespace MauiApp1.View;

public partial class Menu : ContentPage
{

    protected readonly int _idPelada;
    protected readonly string _codPartida;
    public Menu(int idPelada, string codPartida)
    {

        _codPartida = codPartida;
        _idPelada = idPelada;
        InitializeComponent();

    }

    public async void CriarTimes(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new View.ListaJogador(_idPelada, _codPartida));
    }

    public async void PartidaEmAndamneto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new View.PartidaEmAndamento());
    }

}