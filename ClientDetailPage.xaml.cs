using MasterclassApp.Models;

namespace MasterclassApp;

public partial class ClientDetailPage : ContentPage
{
    private Client currentClient;

    public ClientDetailPage(Client client)
    {
        InitializeComponent();
        currentClient = client;
        BindingContext = currentClient;
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientEntryPage(currentClient));
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sterge Client", "Esti sigur ca vrei sa stergi acest client?", "Da", "Nu");

        // if (isUserConfirmed)
        {
            await App.Database.DeleteClientAsync(currentClient);
            await Navigation.PopAsync();
        }
    }
}