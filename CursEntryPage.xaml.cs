using MasterclassApp.Models;

namespace MasterclassApp;

public partial class CursEntryPage : ContentPage
{
    private Curs currentCurs;

    public CursEntryPage()
    {
        InitializeComponent();
        currentCurs = new Curs();
    }

    public CursEntryPage(Curs curs)
    {
        InitializeComponent();
        currentCurs = curs;
        LoadCursDetails();
    }

    private void LoadCursDetails()
    {
        nameEntry.Text = currentCurs.Name;
        descriptionEntry.Text = currentCurs.Description;
        locatieEntry.Text = currentCurs.Locatie;
        dateDatePicker.Date = currentCurs.Date;
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        currentCurs.Name = nameEntry.Text;
        currentCurs.Description = descriptionEntry.Text;
        currentCurs.Locatie = locatieEntry.Text;
        currentCurs.Date = dateDatePicker.Date;      


        await App.Database.SaveCursAsync(currentCurs);
        await Navigation.PopAsync();
    }

}