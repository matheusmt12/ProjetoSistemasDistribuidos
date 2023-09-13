namespace MauiApp1;

public partial class EntrarPartida : ContentPage
{
	public EntrarPartida()
	{
		InitializeComponent();
	}

	
	public async void EnviarInfo(object sende, EventArgs e)
	{
		btnEnviar.Text = "teste";
		SemanticScreenReader.Announce(btnEnviar.Text);
	}


}