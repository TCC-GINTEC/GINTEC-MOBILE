
using CommunityToolkit.Maui.Alerts;

namespace AppGintec.Components.Notification;

public partial class Toast : ContentPage
{
	public Toast()
	{
		InitializeComponent();
	}
    public void Success(string aviso)
    {
        Snackbar.Make($"{aviso}", null, "Fechar", TimeSpan.FromSeconds(5), new CommunityToolkit.Maui.Core.SnackbarOptions
        {
            BackgroundColor = Colors.Green,
            TextColor = Colors.Black,            
        }, alertaImage).Show();
    }

    public void Warn(string aviso)
    {
        Snackbar.Make($"{aviso}", null, "Fechar", TimeSpan.FromSeconds(5), new CommunityToolkit.Maui.Core.SnackbarOptions
        {
            BackgroundColor = Colors.Orange,
            TextColor = Colors.Black,
        }, alertaImage).Show();
    }

    public void Info(string aviso)
    {
        Snackbar.Make($"{aviso}", null, "Fechar", TimeSpan.FromSeconds(5), new CommunityToolkit.Maui.Core.SnackbarOptions
        {
            BackgroundColor = Colors.Yellow,
            TextColor = Colors.Black,
        }, alertaImage).Show();
    }

    public void Error(string aviso)
    {
        Snackbar.Make($"{aviso}", null, "Fechar", TimeSpan.FromSeconds(5), new CommunityToolkit.Maui.Core.SnackbarOptions
        {
            BackgroundColor = Colors.Red,
            TextColor = Colors.Black,
        }, alertaImage).Show();
    }
}