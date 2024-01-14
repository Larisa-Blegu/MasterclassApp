using MasterclassApp.Models;

namespace MasterclassApp;

public partial class ClientPage : ContentPage
{
    public ClientPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadClienti();
    }

    private async void LoadClienti()
    {
        try
        {
            List<Client> clienti = await App.Database.GetClientAsync();
            clientListView.ItemsSource = clienti;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la încãrcarea clien?ilor: {ex.Message}");
        }
    }

    private async void OnAddClientClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientEntryPage());
    }

    private async void OnClientSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Client selectedClient)
        {
            await Navigation.PushAsync(new ClientDetailPage(selectedClient));
            clientListView.SelectedItem = null;
        }
    }
}