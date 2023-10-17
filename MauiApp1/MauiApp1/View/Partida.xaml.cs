using BuscarApi;
using System.Diagnostics;


namespace MauiApp1.View;

public partial class Partida : ContentPage
{

    private Stopwatch stopwatch = new Stopwatch();
    private bool isRunning = false;
    private bool partidaCriada;
    private DadosPartida dadosPartida;
    private readonly List<TimeJogadores>  _lista = new List<TimeJogadores>();
    private TimeJogadores timeVencedor;
    Queue<int> fila = new Queue<int>();
    private int casa = 0,fora = 0;
    //private int fora
    public Partida(List<TimeJogadores> lista)
    {
        dadosPartida = new DadosPartida();
        _lista = lista;
        CriarPartida();
        partidaCriada = true;
        UpdateTimer();
        InitializeComponent();
    }

    public int Sortear(int count)
    {
        Random random = new Random();

        return random.Next(count);

    }

    public async void CriarPartida()
    {
      
        int idCasa = 0;
        int idFora = 0;

 
        int sorteio = Sortear(_lista.Count());
        idCasa = sorteio;
        sorteio = Sortear(_lista.Count());
        while (sorteio == idCasa)
        {
            sorteio = Sortear(_lista.Count());
        }
        idFora = _lista[sorteio].idTime;
        idCasa = _lista[idCasa].idTime;
        foreach(var t in _lista)
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
            TempoDePartida = "teste",
            TimeIdTimeCasa = idCasa,
            TimeIdTimeFora = idFora,
            Status = true
        };
        string nomeTime1 = _lista.FirstOrDefault(g => g.idTime == idCasa)?.nomeDoTime;
        string nomeTime2 = _lista.FirstOrDefault(g => g.idTime == idFora)?.nomeDoTime;
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
        int Tcasa;
        int Tfora;
        dadosPartida.PlacarTimeCasa = (string)casa.ToString();
        await partidaAPI.PutPartida(dadosPartida);
        Tcasa = _lista.Where(g => g.nomeDoTime == time1.Text).Select(g => g.idTime).FirstOrDefault();
        Tfora = _lista.Where(g => g.nomeDoTime == time2.Text).Select(g => g.idTime).FirstOrDefault();
        string nomeTime1 = _lista.FirstOrDefault(g => g.idTime == Tcasa)?.nomeDoTime;
        string nomeTime2 = _lista.FirstOrDefault(g => g.idTime == Tfora)?.nomeDoTime;
        Device.BeginInvokeOnMainThread(() =>
        {
            time1.Text = nomeTime1;
            time2.Text = nomeTime2;
            placarT1.Text = dadosPartida.PlacarTimeCasa;
            placarT2.Text = dadosPartida.PlacarTimeFora;
        });
    }

    public async void Fora(object sender, EventArgs e)
    {
        PartidaAPI partidaAPI = new PartidaAPI();
        fora += 1;
        int Tcasa;
        int Tfora;
        dadosPartida.PlacarTimeFora =(string)fora.ToString();
        await partidaAPI.PutPartida(dadosPartida);
        Tcasa = _lista.Where(g => g.nomeDoTime == time1.Text).Select(g => g.idTime).FirstOrDefault();
        Tfora = _lista.Where(g => g.nomeDoTime == time2.Text).Select(g => g.idTime).FirstOrDefault();
        string nomeTime1 = _lista.FirstOrDefault(g => g.idTime == Tcasa)?.nomeDoTime;
        string nomeTime2 = _lista.FirstOrDefault(g => g.idTime == Tfora)?.nomeDoTime;
        Device.BeginInvokeOnMainThread(() =>
        {
            time1.Text = nomeTime1;
            time2.Text = nomeTime2;
            placarT1.Text = dadosPartida.PlacarTimeCasa;
            placarT2.Text = dadosPartida.PlacarTimeFora;
        });
    }

    public async void EncerrarPartida(object sender, EventArgs e)
    {

        //finaliar partida:
        fora = 0;
        casa = 0;
        PartidaAPI partidaAPI = new PartidaAPI();
        dadosPartida.TempoDePartida = stopwatch.Elapsed.ToString("hh\\:mm\\:ss");
        dadosPartida.PlacarTimeCasa = placarT1.Text;
        dadosPartida.PlacarTimeFora = placarT2.Text;
        dadosPartida.Status = false;
        dadosPartida.InicioPartida = false;

        await partidaAPI.PutPartida(dadosPartida);




        // crinado nova partida
        int idFora = 0;
        int idCasa = 0;
        if (int.Parse(placarT1.Text) > int.Parse(placarT2.Text))
        {
            //o time ue perdeu vai para, 
            //quem
            fila.Enqueue(_lista.Where(g => g.nomeDoTime == time2.Text).Select(g => g.idTime).FirstOrDefault());
            idCasa = _lista.Where(g => g.nomeDoTime == time1.Text).Select(g => g.idTime).FirstOrDefault();
            idFora = fila.Dequeue();
            //this.timeVencedor.idTime = 
        }
        else if (int.Parse(placarT1.Text) == int.Parse(placarT2.Text))
        {
            fila.Enqueue(_lista.Where(g => g.nomeDoTime == time1.Text).Select(g => g.idTime).FirstOrDefault());
            fila.Enqueue(_lista.Where(g => g.nomeDoTime == time2.Text).Select(g => g.idTime).FirstOrDefault());
            idCasa = fila.Dequeue();
            idFora = fila.Dequeue();
        }
        else
        {
            fila.Enqueue(_lista.Where(g => g.nomeDoTime == time1.Text).Select(g => g.idTime).FirstOrDefault());
            idCasa = _lista.Where(g => g.nomeDoTime == time2.Text).Select(g => g.idTime).FirstOrDefault();
            idFora = fila.Dequeue();
        }


        dadosPartida = new DadosPartida
        {
            InicioPartida = true,
            PlacarTimeCasa = "0",
            PlacarTimeFora = "0",
            TempoDePartida =  "--",
            TimeIdTimeCasa = idCasa,
            TimeIdTimeFora = idFora,
            Status = false
        };
        string nomeTime1 = _lista.FirstOrDefault(g => g.idTime == idCasa)?.nomeDoTime;
        string nomeTime2 = _lista.FirstOrDefault(g => g.idTime == idFora)?.nomeDoTime;
        dadosPartida = await partidaAPI.PostPartida(dadosPartida);
        Device.BeginInvokeOnMainThread(() =>
        {
            time1.Text = nomeTime1;
            time2.Text = nomeTime2;
            placarT1.Text = dadosPartida.PlacarTimeCasa;
            placarT2.Text = dadosPartida.PlacarTimeFora;
        });

    }

    //Cronometro

    private async Task UpdateTimer()
    {
        while (true)
        {
            await Task.Delay(100); // Aguarda 100 milissegundos
            if (isRunning)
            {
                Device.BeginInvokeOnMainThread(() => { lblTimer.Text = stopwatch.Elapsed.ToString("hh\\:mm\\:ss"); });
            }
        }
    }

    private async void OnStartStopButtonClicked(object sender, EventArgs e)
    {
        if (isRunning)
        {
            stopwatch.Stop();
           
        }
        else
        {
            stopwatch.Start();
        }
        isRunning = !isRunning;
    }

    private void OnResetButtonClicked(object sender, EventArgs e)
    {
        stopwatch.Reset();
        lblTimer.Text = "00:00:00";
        isRunning = false;
    }

}