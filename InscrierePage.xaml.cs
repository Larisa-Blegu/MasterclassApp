using MasterclassApp.Models;

namespace MasterclassApp;

public partial class InscrierePage : ContentPage
{
	public InscrierePage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadInscrieri();
    }

        private async void LoadInscrieri()
        {
            try
            {
                Console.WriteLine("Ce se inampla\n");
                List<InscriereDTO> inscrieriDTO = await App.Database.GetInscriereDTOAsync();

                // Afi?eazã numãrul de elemente în consolã
                Console.WriteLine($"Numãrul de inscrieriDTO: {inscrieriDTO.Count}");

                inscriereListView.ItemsSource = inscrieriDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la încãrcarea inscrieri: {ex.Message}");
            }

        }
        private async void OnAddInscriereClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InscriereEntryPage());
    }

    private async void OnInscriereSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is InscriereDTO selectedInscriere)
        {
            Inscriere inscriere = App.Database.GetInscriereAsync(selectedInscriere.Curs).Result;
            await Navigation.PushAsync(new InscriereDetailPage(inscriere,selectedInscriere));
            inscriereListView.SelectedItem = null;
        }
    }

}