using MasterclassApp.Models;

namespace MasterclassApp;

public partial class CursPage : ContentPage
{
	public CursPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadCursuri();
    }
    private async void LoadCursuri()
    {
        try
        {
             List<Curs> cursuri = await App.Database.GetCursAsync();
             cursListView.ItemsSource = cursuri;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la încãrcarea clien?ilor: {ex.Message}");
        }
    }
    private async void OnAddCursClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CursEntryPage());
    }

    private async void OnCursSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Curs selectedCurs)
        {
            await Navigation.PushAsync(new CursDetailPage(selectedCurs));
            cursListView.SelectedItem = null;
        }
    }
}