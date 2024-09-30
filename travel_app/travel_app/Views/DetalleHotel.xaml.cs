using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travel_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleHotel : ContentPage
    {
        private int hotelId;

        public DetalleHotel(int id)
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
    }
}