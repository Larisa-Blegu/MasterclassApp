using MasterclassApp.Auth;
using MasterclassApp.Models;

namespace MasterclassApp;

public partial class LoginPage : ContentPage
{
    private UserService userService = new UserService();
    public LoginPage()
    {
        InitializeComponent();
        Shell.SetTabBarIsVisible(Application.Current, false);
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string email = emailEntry.Text;
        string parola = parolaEntry.Text;

        int? userId = await App.Database.GetUserIdByEmailAndPasswordAsync(email, parola);

        Client authenticatedClient = await userService.AuthenticateClientAsync(email, parola);

        if (authenticatedClient != null)
        {
            int loggedInUserId = userId.Value;
            
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Login nereusit", "Email sau parola invalida", "OK");
        }
    }


    private async void OnSignButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AuthPage());
    }
}