using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using travel_app.Models;
using travel_app.Services;
using Xamarin.Forms;

namespace travel_app.ViewModels
{
    public class HotelViewModel : BaseViewModel
    {
        private ApiService _apiService;
        public ObservableCollection<Hotel> Hoteles { get; set; }

        public HotelViewModel()
        {
            _apiService = new ApiService();
            Hoteles = new ObservableCollection<Hotel>();

            // Comando para cargar las reservas
            LoadHotelesCommand = new Command(async () => await LoadHoteles());
        }

        public Command LoadHotelesCommand { get; }

        // Método para cargar las reservas llamando al servicio
        private async Task LoadHoteles()
        {
            try
            {
                // Llamada al servicio que obtiene las reservas del usuario
                var reservas = await _apiService.GetAsync<List<Hotel>>("hoteles");

                Hoteles.Clear();
                foreach (var reserva in reservas)
                {
                    Hoteles.Add(reserva);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
