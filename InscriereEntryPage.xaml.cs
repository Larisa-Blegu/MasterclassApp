using MasterclassApp.Models;

namespace MasterclassApp;

public partial class InscriereEntryPage : ContentPage
{
    private Inscriere currentInscriere;

    public InscriereEntryPage()
    {
        InitializeComponent();
        currentInscriere = new Inscriere();
    }

    public InscriereEntryPage(Inscriere inscriere)
    {
        InitializeComponent();
        currentInscriere = inscriere;
        LoadInscriereDetails();
    }

    private void LoadInscriereDetails()
    {
        clientIDEntry.Text = currentInscriere.ClientID.ToString();
        biletIDEntry.Text = currentInscriere.BiletID.ToString();
        cursIDEntry.Text = currentInscriere.CursID.ToString();
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        currentInscriere.ClientID = int.Parse(clientIDEntry.Text);
        currentInscriere.BiletID = int.Parse(biletIDEntry.Text);
        currentInscriere.CursID = int.Parse(cursIDEntry.Text);

        await App.Database.SaveInscriereAsync(currentInscriere);
        await DisplayAlert("Success", "Inscriere saved successfully!", "OK");
        await Navigation.PopAsync();
    }
}