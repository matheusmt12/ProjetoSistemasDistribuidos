using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.Maui.Controls;

namespace MauiApp1;

public partial class Cronometro : ContentPage
{

	private Stopwatch stopwatch = new Stopwatch();
	private bool isRunning = false;
	public Cronometro()
	{
		InitializeComponent();
        UpdateTimer();
	}

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