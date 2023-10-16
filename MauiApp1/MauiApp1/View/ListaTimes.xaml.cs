using BuscarApi;

namespace MauiApp1.View;

public partial class ListaTimes : ContentPage
{
    protected int idPelada;
    protected List<TimeJogadores> lista = new List<TimeJogadores>();

    public ListaTimes(int idPelada, List<TimeJogadores> lista)
	{
        this.idPelada = idPelada;
		InitializeComponent();
        this.lista = lista;
        AddTeamsToLayout(this.lista);
    }

    private async void OnGenerateTeamsClicked(object sender, EventArgs e)
    {
        TimeAPI timeAPI = new TimeAPI(); 
        this.lista = new List<TimeJogadores>();
        this.lista = await timeAPI.GetTeamsAsync(this.idPelada);

        TeamsFlexLayout.Children.Clear();
        AddTeamsToLayout(this.lista);

        //TeamsCollectionView.ItemsSource = lista;
    }   

    private void AddTeamsToLayout(List<TimeJogadores> times)
    {
      

        foreach (var time in times)
        {
            var stackLayout = new StackLayout
            {
                Spacing = 10
                             // Espaçamento vertical dentro de cada time
            };

            var nomeDoTimeLabel = new Label
            {
                Text = time.nomeDoTime,
                FontAttributes = FontAttributes.Bold,
                FontSize = 20
                
            };

            stackLayout.Children.Add(nomeDoTimeLabel);

            foreach (var jogador in time.nomeDosJogadores)
            {
                var jogadorLabel = new Label
                {
                    Text = jogador,
                  

                };
                stackLayout.Children.Add(jogadorLabel);
            }

            TeamsFlexLayout.Children.Add(stackLayout);
        }
    }
}