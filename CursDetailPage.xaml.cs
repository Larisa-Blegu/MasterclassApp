using MasterclassApp.Models;

namespace MasterclassApp;

public partial class CursDetailPage : ContentPage
{
    private Curs currentCurs;

    public CursDetailPage(Curs curs)
    {
        InitializeComponent();
        currentCurs = curs;
        BindingContext = currentCurs;
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CursEntryPage(currentCurs));
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sterge Curs", "Esti sigur ca vrei sa stergi acest Curs?", "Da", "Nu");
        await App.Database.DeleteCursAsync(currentCurs);
        await Navigation.PopAsync();
    }

}