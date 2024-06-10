using AppGintec.Models;
using AppGintec.Pages;
using AppGintec.Service;
using Newtonsoft.Json;
using System.Text.Json;

namespace AppGintec
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            ApiService<LoginResponse> api = new();

            var data = api.PostAsync("Auth", new
            {
                email = UsernameEntry.Text,
                password = PasswordEntry.Text
            });            
            if (data.StatusCode == 200)
            {
                ApiService<object>._accessToken = data.Data.token;
                Navigation.PushAsync(new Home());
            }
            else if (data.StatusCode == 401)
                Toast.Warn("E-mail ou usuário inválido!");
            else
                Toast.Error("Algo deu errado. Por favor contate o administrador!");
        }
    }

}
