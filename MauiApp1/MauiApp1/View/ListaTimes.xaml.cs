using BuscarApi;

namespace MauiApp1.View;

public partial class ListaTimes : ContentPage
{
	public ListaTimes()
	{
		InitializeComponent();
	}

    private async void OnGenerateTeamsClicked(object sender, EventArgs e)
    {
        //TimeAPI timeAPI = new TimeAPI();
        List<TimeJogadores> lista = new List<TimeJogadores>();
        lista = GenerateTeamsData();

        TeamsCollectionView.ItemsSource = lista;
    }

    private List<TimeJogadores> GenerateTeamsData()
    {
        // Coloque o código para gerar times e jogadores aqui
        // Este método deve retornar uma lista de objetos TimeJogadoreDTO preenchida
        // com os times e jogadores gerados
        // Substitua isso pelo seu código real
        return new List<TimeJogadores>
        {
            new TimeJogadores
            {
                nomeDoTime = "Time A",
                nomeDosJogadores = new List<string> { "jose", "john", "matheus", "guilherme", "ruan" }
            },
            new TimeJogadores
            {
                nomeDoTime = "Time B",
                nomeDosJogadores = new List<string> { "lucas", "moises", "maria", "otaci", "junio" }
            },
             new TimeJogadores
            {
                nomeDoTime = "Time C",
                nomeDosJogadores = new List<string> { "lucas", "moises", "maria", "otaci", "junio" }
            }
            
        };
    }
}