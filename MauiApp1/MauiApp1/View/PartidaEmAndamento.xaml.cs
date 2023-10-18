using BuscarApi;
using System.Collections.Generic;

namespace MauiApp1.View;

public partial class PartidaEmAndamento : ContentPage
{
    public PartidaEmAndamento()
    {
        InitializeComponent();
        Ver();
    }
    public async void Ver()
    {

        PartidaAPI partida = new PartidaAPI();

        List<DadosPartidaDTO> list = new List<DadosPartidaDTO>();

        list = await partida.GetPartidaEmAndamento();


        foreach (var partidas in list)
        {
            var stacklayout = new StackLayout
            {
                Spacing = 10,
            };



            var label = new Label
            {

                Text = partidas.NomeTimeCasa + " Gol(s) :" + partidas.PlacarTimeCasa + "   X   " + partidas.NomeTimeFora + "Gol(s)" + partidas.PlacarTimeFora
            };
            stacklayout.Children.Add(label);
            TeamsFlexLayout.Children.Add(stacklayout);


        }
    }

    private async void OnLabelClicked(object sender, EventArgs e)
    {
        TeamsFlexLayout.Children.Clear();
        Ver();
    }
}