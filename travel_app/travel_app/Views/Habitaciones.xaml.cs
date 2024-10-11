using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	public partial class Habitaciones : ContentPage
	{
		private int hotelId;
		public Habitaciones (int id)
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

        private async void Reserva_Clicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as DetalleHotelViewModel;
            if (viewModel != null && viewModel.Habitaciones != null)
            {
                var popup = new ReservaPopup(viewModel.Habitaciones.ToList()); // Pasa la lista de habitaciones
                await PopupNavigation.Instance.PushAsync(popup);
            }
        }
    }
}