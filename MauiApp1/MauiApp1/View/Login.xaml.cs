namespace MauiApp1.View;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

	public async void Teste(object sender, EventArgs e)
	{
		PeladaAPI api = new PeladaAPI();
		teste.Text = await api.GetDadosAPI();
	}
}