using MasterclassApp.Models;

namespace MasterclassApp;

public partial class BiletEntryPage : ContentPage
{
    private Bilet currentBilet;

    public BiletEntryPage()
    {
        InitializeComponent();
        currentBilet = new Bilet();
    }

    public BiletEntryPage(Bilet bilet)
    {
        InitializeComponent();
        currentBilet = bilet;
        LoadBiletDetails();
    }

    private void LoadBiletDetails()
    {
        tipEntry.Text = currentBilet.Tip;
        pretEntry.Text = currentBilet.Pret.ToString();
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        currentBilet.Tip = tipEntry.Text;
        currentBilet.Pret = int.Parse(pretEntry.Text);

        await App.Database.SaveBiletAsync(currentBilet);
        await DisplayAlert("Success", "Bilet saved successfully!", "OK");
        await Navigation.PopAsync();
    }
}