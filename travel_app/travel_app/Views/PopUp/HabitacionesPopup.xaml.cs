using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using travel_app.Models;
using travel_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travel_app.Views.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HabitacionesPopup : PopupPage
    {
        private int hotelId;

        public HabitacionesPopup(int id)
        {
            InitializeComponent();
            BindingContext = new DetalleHotelViewModel();
            hotelId = id;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            var viewModel = BindingContext as DetalleHotelViewModel;
            if (viewModel != null)
            {
                viewModel.LoadHotelDetailsCommand.Execute(hotelId); // Ejecutar el comando para cargar los detalles del hotel
            }
        }

        [Obsolete]
        private async void CerrarHabitaciones(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }
        // Evento del botón Reservar
        private async void Reservar_Clicked(object sender, EventArgs e)
        {
            // Navegar a ReservaPage
            await Navigation.PushAsync(new ReservaPage());
        }
    }
}