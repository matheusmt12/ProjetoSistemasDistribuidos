using BuscarApi;
using System.Diagnostics;


namespace MauiApp1.View;

public partial class Partida : ContentPage
{

    private Stopwatch _stopwatch;
    private bool partidaCriada;
    private DadosPartida dadosPartida;
    private List<TimeJogadores>  lista = new List<TimeJogadores>();
    private TimeJogadores timeVencedor;
    Queue<int> fila = new Queue<int>();
    private int casa = 0,fora = 0;
    //private int fora
    public Partida(List<TimeJogadores> lista)
    {
        dadosPartida = new DadosPartida();
        lista = lista;
        CriarPartida();
        partidaCriada = true;
        InitializeComponent();
    }

    public int Sortear(int count)
    {
        Random random = new Random();

        return random.Next(count + 1);

    }

    public async void CriarPartida()
    {
      
        int idCasa = 0;
        int idFora = 0;

 
        int sorteio = Sortear(lista.Count());
        idCasa = sorteio;
        sorteio = Sortear(lista.Count()-1);
        while (sorteio == idCasa)
        {
            sorteio = Sortear(lista.Count() - 1);
        }
        idFora = lista[sorteio].idTime;
        idCasa = lista[idCasa].idTime;
        foreach(var t in lista)
        {
            if(t.idTime !=  idCasa || t.idTime != idFora)
            {
                fila.Enqueue(t.idTime);
            }
        }   
        
        PartidaAPI partidaAPI = new PartidaAPI();
        dadosPartida = new DadosPartida
        {
            InicioPartida = false,
            PlacarTimeCasa = "0",
            PlacarTimeFora = "0",
            TempoDePartida = DateTime.Now,
            TimeIdTimeCasa = idCasa,
            TimeIdTimeFora = idFora,
        };
        string nomeTime1 = lista.FirstOrDefault(g => g.idTime == idCasa)?.nomeDoTime;
        string nomeTime2 = lista.FirstOrDefault(g => g.idTime == idCasa)?.nomeDoTime;
        dadosPartida = await partidaAPI.PostPartida(dadosPartida);
        Device.BeginInvokeOnMainThread(() =>
        {
            time1.Text = nomeTime1;
            time2.Text = nomeTime2;
            placarT1.Text = dadosPartida.PlacarTimeCasa;
            placarT2.Text = dadosPartida.PlacarTimeFora;
        });

    }

    public async void Casa(object sender, EventArgs e)
    {
        PartidaAPI partidaAPI = new PartidaAPI();
        casa += 1;
        dadosPartida.PlacarTimeCasa = (string)casa.ToString();
        await partidaAPI.PutPartida(dadosPartida);

        Device.BeginInvokeOnMainThread(() =>
        {
            time1.Text = dadosPartida.TimeIdTimeCasa.ToString();
            time2.Text = dadosPartida.TimeIdTimeFora.ToString();
            placarT1.Text = dadosPartida.PlacarTimeCasa;
            placarT2.Text = dadosPartida.PlacarTimeFora;
        });
    }

    public async void Fora(object sender, EventArgs e)
    {
        PartidaAPI partidaAPI = new PartidaAPI();
        fora += 1;
        dadosPartida.PlacarTimeFora =(string)fora.ToString();
        await partidaAPI.PutPartida(dadosPartida);

        Device.BeginInvokeOnMainThread(() =>
        {
            time1.Text = dadosPartida.TimeIdTimeCasa.ToString();
            time2.Text = dadosPartida.TimeIdTimeFora.ToString();
            placarT1.Text = dadosPartida.PlacarTimeCasa;
            placarT2.Text = dadosPartida.PlacarTimeFora;
        });
    }

    public async void EncerrarPartida(object sender, EventArgs e)
    {
        int idTime = fila.Dequeue();
        //verificr quem ganhou
        //
        if (int.Parse(placarT1.Text) > int.Parse(placarT2.Text))
        {
            //o time ue perdeu vai para, 
            //quem

        }

      
        PartidaAPI partidaAPI = new PartidaAPI();
        dadosPartida = new DadosPartida
        {
            InicioPartida = false,
            PlacarTimeCasa = "0",
            PlacarTimeFora = "0",
            TempoDePartida = DateTime.Now,
            TimeIdTimeCasa = this.timeVencedor.idTime,
            TimeIdTimeFora = idTime,
        };
        string nomeTime1 = lista.FirstOrDefault(g => g.idTime == this.timeVencedor.idTime)?.nomeDoTime;
        string nomeTime2 = lista.FirstOrDefault(g => g.idTime == idTime)?.nomeDoTime;
        dadosPartida = await partidaAPI.PostPartida(dadosPartida);
        Device.BeginInvokeOnMainThread(() =>
        {
            time1.Text = nomeTime1;
            time2.Text = nomeTime2;
            placarT1.Text = dadosPartida.PlacarTimeCasa;
            placarT2.Text = dadosPartida.PlacarTimeFora;
        });

    }

}