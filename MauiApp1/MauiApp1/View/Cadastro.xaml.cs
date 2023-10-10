using BuscarApi;

namespace MauiApp1.View;

public partial class Cadastro : ContentPage
{
	public Cadastro()
	{
		InitializeComponent();
	}

	public async void EnviarInfo(object sender, EventArgs e)
	{
		Jogador jogadorApi = new Jogador();

		if(senha1.Text != senha2.Text)
		{
           await DisplayAlert("Erro", "A senha não são a mesma","Confirmar");
		}
		else
		{
			JogadorObject jogador = new JogadorObject();

			jogador.Senha = senha1.Text;
			jogador.PosicaoJogador = (string)pickerJogador.SelectedItem.
				ToString().ToUpper();
			jogador.UserName = login.Text;
			jogador.NomeJogador = NomeIforme.Text;

			await jogadorApi.PostDados(jogador);
		}
	}
}