namespace MauiApp1.View;

public partial class CodigoPelada : ContentPage
{
	public CodigoPelada()
	{
		InitializeComponent();
	}
	public async void EntrarPelada(object sender, EventArgs e)
	{
		PeladaAPI pelada = new PeladaAPI();
		var idPelada = await pelada.GetPeladaByCod(codPelada.Text);
		if(idPelada > 0)
		{
            await DisplayAlert("Sucesso", "Pelada encontrado!", "Confirmar");
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