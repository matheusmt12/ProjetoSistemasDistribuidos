namespace MauiApp1;

public partial class NewPage1 : ContentPage
{

	private Label _dadosLabel;
	private Label _dadosString;
	public NewPage1()
	{
		_dadosLabel = new Label();
		Content = _dadosLabel;
		_dadosString = new Label();
		Content = _dadosString;
		CarregarDadosDaApi();
	}

	private async void CarregarDadosDaApi()
	{
		var apiService = new DadosAPI();
		var dados = await apiService.GetDadosAPI();
		if(dados == null)
		{
			_dadosLabel.Text = string.Empty;
		}
		_dadosLabel.Text = dados;

		//var dadosString = await apiService.PostDados();
		_dadosString.Text = dados;
	}
	
}