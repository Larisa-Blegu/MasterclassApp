using MasterclassApp.Models;

namespace MasterclassApp;

public partial class BiletPage : ContentPage
{
	public BiletPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadBilet();
    }

    private async void LoadBilet()
    {
        try
        {
            List<Bilet> bilete = await App.Database.GetBiletAsync();
            biletListView.ItemsSource = bilete;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la încãrcarea biletelor: {ex.Message}");
        }
    }

    private async void OnAddBiletClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BiletEntryPage());
    }

    private async void OnBiletSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Bilet selectedBilet)
        {
            await Navigation.PushAsync(new BiletDetailPage(selectedBilet));
            biletListView.SelectedItem = null;
        }
    }
}