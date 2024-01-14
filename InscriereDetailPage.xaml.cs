using MasterclassApp.Models;

namespace MasterclassApp;

public partial class InscriereDetailPage : ContentPage
{
    private Inscriere currentInscriere;
    private InscriereDTO currentInscriereDTO;

    public InscriereDetailPage(Inscriere inscriere, InscriereDTO inscriereDTO)
    {
        InitializeComponent();
        currentInscriere = inscriere;
        currentInscriereDTO = inscriereDTO;
        BindingContext = currentInscriereDTO;
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InscriereEntryPage(currentInscriere));
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sterge Inscriere", "Esti sigur ca vrei sa stergi acesta inscriere?", "Da", "Nu");
        await App.Database.DeleteInscriereAsync(currentInscriere);
        await Navigation.PopAsync();
    }
}