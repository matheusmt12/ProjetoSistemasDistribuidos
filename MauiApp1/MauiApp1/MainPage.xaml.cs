using MauiApp1.View;

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
		await Navigation.PushAsync(new Login());
	}

    private async void OnLabelClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Cadastro());
    }

}

