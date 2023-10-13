using BuscarApi;

namespace MauiApp1.View;

public partial class CodigoPelada : ContentPage
{
    private int idJogador;
    public CodigoPelada(int id)
	{
		this.idJogador = id;
		InitializeComponent();
	}
	public async void EntrarPelada(object sender, EventArgs e)
	{
		PeladaAPI pelada = new PeladaAPI();
		var idPelada = await pelada.GetPeladaByCod(codPelada.Text);
		if(idPelada > 0)
		{
            ListaJogador addLista = new ListaJogador();
			addLista.peladaIdPelada = idPelada;
			addLista.jogadorIdJogador = this.idJogador;
			bool resposta = await pelada.InsertJogadorInPelada(addLista);
			if(resposta == true) {
                await DisplayAlert("Sucesso", "Jogador Inserido na pelada!", "Confirmar");
            }
			else
			{
                await DisplayAlert("Erro", "Ocorreu um erro, não foi possível inserir!", "Confirmar");
            }
		}
		else
		{
            await DisplayAlert("Erro", "Pelada nao encontrada!", "Confirmar");
        }

	}

    public async void CriarPelada(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CriarPartida());
	}
}