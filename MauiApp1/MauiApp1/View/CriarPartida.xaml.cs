using BuscarApi;

namespace MauiApp1;

public partial class CriarPartida : ContentPage
{
    private int idJogador;
    public CriarPartida(int idJogador)
    {
        InitializeComponent();
        this.idJogador = idJogador;
    }

    private async void btnCriarPartida_Clicked(object sender, EventArgs e)
    {
        var dadosApi = new DadosApi();
        ListaJogadorId listaJogador = new ListaJogadorId();
        PeladaAPI pelada = new PeladaAPI();
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
        dadosApi.Nome = nomePelada.Text;
        dadosApi.Data = dataPelada.Date;
        dadosApi.Local = nomeLocal.Text;
        dadosApi.QuantJogadorPorTime = int.Parse(quantJogadores.Text);
        string receive = await dadosParaEnviar.PostDados(dadosApi);
        if (receive == "Sucesso")
        {
            listaJogador.jogadorIdJogador = idJogador;
            listaJogador.peladaIdPelada = await dadosParaEnviar.GetPeladaByCod(codigo);
            await DisplayAlert("Sucesso", "O código da pelada é " + codigo, "Confirmar");

            if (await pelada.InsertJogadorInPelada(listaJogador) == "Sucesso")
            {
                await Navigation.PushAsync(new View.ListaJogador(listaJogador.peladaIdPelada,codigo));
                
            }
        }

        // JogadorObject jogador = new JogadorObject();

        // jogador.CodigoTorneio = codigo;
        // jogador.NomeJogador = nomeJogador.Text;
        // jogador.Status = "Dono";
        // jogador.PosicaoJogador = (string)pickerJogador.SelectedItem;

        //await  criarJogador.PostDados(jogador);

    }
}