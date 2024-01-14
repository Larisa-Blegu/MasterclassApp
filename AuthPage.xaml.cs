using MasterclassApp.Models;

namespace MasterclassApp;

public partial class AuthPage : ContentPage
{
    public AuthPage()
    {
        InitializeComponent();
        Shell.SetTabBarIsVisible(Application.Current, false);
    }

    private async void OnSignUpButtonClicked(object sender, EventArgs e)
    {
        string email = emailEntry.Text;
        string parola = parolaEntry.Text;
        string nume = numeEntry.Text;
        string prenume = prenumeEntry.Text;


        Client newClient = new Client { Email = email, Parola = parola, Nume = nume, Prenume = prenume };
        await App.Database.SaveClientAsync(newClient);

        await DisplayAlert("Sign reusit", "Cont creat+.", "OK");
        await Navigation.PushAsync(new MainPage());
    }
}