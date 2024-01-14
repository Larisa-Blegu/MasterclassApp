using System;
using MasterclassApp.Models;

namespace MasterclassApp
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var curs = (Curs)BindingContext;
            curs.Date = DateTime.UtcNow;

            await App.Database.SaveCursAsync(curs); 
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var curs = (Curs)BindingContext;
            await App.Database.DeleteCursAsync(curs); 
            await Navigation.PopAsync();
        }
    }
}
