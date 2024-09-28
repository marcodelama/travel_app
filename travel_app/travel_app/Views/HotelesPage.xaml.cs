using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_app.Models;
using travel_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travel_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HotelesPage : ContentPage
    {
        public HotelesPage()
        {
            InitializeComponent();
            BindingContext = new HotelViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var viewModel = BindingContext as HotelViewModel;
            if (viewModel != null)
            {
                viewModel.LoadHotelesCommand.Execute(null);
            }
        }
        private async void OnDetailPage(object sender, EventArgs e)
        {
            var button = sender as Button;
            var selectedHotel = button.BindingContext as Hotel; // Obtener el hotel desde el contexto de enlace

            if (selectedHotel != null)
            {
                await Navigation.PushAsync(new DetalleHotel(selectedHotel.Id)); // Navegar pasando el ID del hotel
            }
        }
    }
}