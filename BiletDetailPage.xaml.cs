using MasterclassApp.Models;

namespace MasterclassApp;

public partial class BiletDetailPage : ContentPage
{
    private Bilet currentBilet;

    public BiletDetailPage(Bilet bilet)
    {
        InitializeComponent();
        currentBilet = bilet;
        BindingContext = currentBilet;
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BiletEntryPage(currentBilet));
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sterge Bilet", "Esti sigur ca vrei sa stergi acest bilet?", "Da", "Nu");
        await App.Database.DeleteBiletAsync(currentBilet);
        await Navigation.PopAsync();

    }
}