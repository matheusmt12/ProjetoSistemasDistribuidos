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
            await DisplayAlert("Sucesso", "Usuário encontrado!", "Confirmar");
		}

	}
}