namespace MauiApp1;

public partial class CriarPartida : ContentPage
{

	private Label _labelIni;
	private Entry _entryName;
	private Label _receiveApi;
	private Button _criarPartida;
	
	public CriarPartida()
	{
		_entryName = new Entry()
		{
			Placeholder = "Info"
		};

		_labelIni = new Label()
		{
			Text = "Criar partida"
		};
		_receiveApi = new Label();

		_criarPartida = new Button()
		{
			Text = "Confirmar"
		};

		_criarPartida.Clicked += btnCriarPartida_Clicked;
		Content = new StackLayout
		{
			Children = { _labelIni, _entryName,_criarPartida,_receiveApi}
		};
	}

    private async void btnCriarPartida_Clicked(object sender, EventArgs e)
    {
		var dadosApi = new DadosApi();
		var dadosParaEnviar = new DadosAPI();

		dadosApi.Data = DateTime.Now;
		dadosApi.CodigoPelada = "1235468";
		dadosApi.Nome = _entryName.Text;

		string receive = await dadosParaEnviar.PostDados(dadosApi);

		_receiveApi.Text = receive;
    }
}