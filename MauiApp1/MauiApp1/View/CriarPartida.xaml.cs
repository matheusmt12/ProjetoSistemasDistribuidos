using BuscarApi;

namespace MauiApp1;

public partial class CriarPartida : ContentPage
{

    public CriarPartida()
    {
        InitializeComponent();
    }

    private async void btnCriarPartida_Clicked(object sender, EventArgs e)
    {
        var dadosApi = new DadosApi();
        var dadosParaEnviar = new PeladaAPI();
        var criarJogador = new Jogador();


        Random r = new Random();

        string codigo = String.Empty;
        for (int i = 0; i < 6; i++)
        {
            int random = r.Next(10);
            codigo += random.ToString();
        }
        DateTime horas = DateTime.Now;

        //criando pelada
        dadosApi.CodigoPelada = codigo;
        dadosApi.Nome = nomePartida.Text;
        dadosApi.Data = DateTime.Now;

        string receive = await dadosParaEnviar.PostDados(dadosApi);
        if (receive == "Sucesso")
            textoCodigoPartida.Text = receive + ": " + "O código da pelada é " + codigo;


        JogadorObject jogador = new JogadorObject();

        jogador.CodigoTorneio = codigo;
        jogador.NomeJogador = nomeJogador.Text;
        jogador.Status = "Dono";
        jogador.PosicaoJogador = (string)pickerJogador.SelectedItem;

       await  criarJogador.PostDados(jogador);

    }
}