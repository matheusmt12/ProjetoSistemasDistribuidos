using BuscarApi;
using MauiApp1.View;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		//count++;

		//if (count == 1)
		//	CounterBtn.Text = $"Clicked {count} time";
		//else
		//	CounterBtn.Text = $"Clicked {count} times";

		//SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private async void EntrarPartida(object sender, EventArgs e)
	{
		Jogador jogadorApi = new Jogador();
		string resposta = await jogadorApi.GetLogin(login.Text, senha.Text);
		if (resposta.Equals("Encontrado"))
		{
            await Navigation.PushAsync(new CodigoPelada());
        }
		else
		{
            await DisplayAlert("Erro", "Usuário nao encontrado!", "Confirmar");
        }
		
	}

    private async void OnLabelClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Cadastro());
    }

	public async void Teste(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new View.ListaJogador());
	}
}

