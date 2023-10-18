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
			ListaJogadorId addLista = new ListaJogadorId();
			addLista.peladaIdPelada = idPelada;
			addLista.jogadorIdJogador = this.idJogador;
			string resposta = await pelada.InsertJogadorInPelada(addLista);
			if(resposta == "Sucesso") {
                await DisplayAlert("Sucesso", "Jogador Inserido na pelada!", "Confirmar");
                await Navigation.PushAsync(new View.Menu(idPelada, codPelada.Text));
            }
			else if(resposta == "OK")
			{
                await DisplayAlert("Sucesso",resposta, "Confirmar");
				await Navigation.PushAsync(new View.Menu(idPelada, codPelada.Text));
            }
		}
		else
		{
            await DisplayAlert("Erro", "Pelada nao encontrada!", "Confirmar");
        }

	}

    public async void CriarPelada(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CriarPartida(idJogador));
	}
}