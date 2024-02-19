using BuscarApi;

namespace MauiApp1.View;

public partial class Cadastro : ContentPage
{
    public Cadastro()
    {
        InitializeComponent();
    }

    public async void EnviarInfo(object sender, EventArgs e)
    {
        Jogador jogadorApi = new Jogador();


        
        if (senha1.Text.Count() < 6)
        {
            await DisplayAlert("Aten��o", "A Senha deve ter no minimo 6 caracteres", "OK");
        }
        else if (senha1.Text != senha2.Text)
        {
            await DisplayAlert("Erro", "A senha n�o s�o a mesma", "Confirmar");
        }
        else
        {
            JogadorObject jogador = new JogadorObject();


            if (string.IsNullOrWhiteSpace(NomeIforme.Text))
            {
                await DisplayAlert("Aten��o", "O campo Nome � obrigat�rio", "OK");
            }
            else if (string.IsNullOrWhiteSpace(login.Text))
            {

                await DisplayAlert("Aten��o", "O campo Login � obrigat�rio", "OK");

            }
            else if (string.IsNullOrWhiteSpace(senha1.Text) || string.IsNullOrWhiteSpace(senha2.Text))
            {
                await DisplayAlert("Aten��o", "O campo Senha � obrigat�rio", "OK");

            }
            else
            {

                jogador.Senha = senha1.Text;
                jogador.PosicaoJogador = (string)pickerJogador.SelectedItem.
                    ToString().ToUpper();
                jogador.UserName = login.Text;
                jogador.NomeJogador = NomeIforme.Text;

                var response = await jogadorApi.PostDados(jogador);
                if (response.Equals("Sucesso"))
                {
                    await DisplayAlert("Sucesso", "Cadastro Feito!", "Comfirmar");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Erro", response, "Comfirmar");
                }
            }


        }
    }
}