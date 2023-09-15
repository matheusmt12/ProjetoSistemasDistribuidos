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
		await Navigation.PushAsync(new EntrarPartida());
	}

	private async void Teste(object sender, EventArgs args)
	{
		await Navigation.PushAsync(new NewPage1());	
	}

	private async void CriarPartida(object sender,EventArgs args)
	{
		await Navigation.PushAsync(new CriarPartida());
    }

}

