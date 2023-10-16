using BuscarApi;

namespace MauiApp1.View;

public partial class ListaTimes : ContentPage
{
	public ListaTimes()
	{
		InitializeComponent();
        AddTeamsToLayout();

    }

    private async void OnGenerateTeamsClicked(object sender, EventArgs e)
    {
        //TimeAPI timeAPI = new TimeAPI();
        List<TimeJogadores> lista = new List<TimeJogadores>();
        lista = GenerateTeamsData();

        //TeamsCollectionView.ItemsSource = lista;
    }

    private List<TimeJogadores> GenerateTeamsData()
    {
        // Coloque o c�digo para gerar times e jogadores aqui
        // Este m�todo deve retornar uma lista de objetos TimeJogadoreDTO preenchida
        // com os times e jogadores gerados
        // Substitua isso pelo seu c�digo real
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

    private void AddTeamsToLayout()
    {
        var times = new List<TimeJogadores>
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

        foreach (var time in times)
        {
            var stackLayout = new StackLayout
            {
                Spacing = 10
                             // Espa�amento vertical dentro de cada time
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