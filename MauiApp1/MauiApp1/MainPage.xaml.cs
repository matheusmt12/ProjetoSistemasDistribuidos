using BuscarApi;
using MauiApp1.View;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MauiApp1;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void EntrarPartida(object sender, EventArgs e)
	{
		Jogador jogadorApi = new Jogador();
		int idJogador = await jogadorApi.GetLogin(login.Text, senha.Text);
		if (idJogador > 0)
		{
            await Navigation.PushAsync(new CodigoPelada(idJogador));
        }
		else
		{
            await DisplayAlert("Erro", "Usuário nao encontrado!", "Confirmar");
        }
		
	}

	private async void Teste(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Cronometro());
	}
    private async void OnLabelClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Cadastro());
    }

}

