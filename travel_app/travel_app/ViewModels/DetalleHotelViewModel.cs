using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using travel_app.Models;
using travel_app.Services;
using Xamarin.Forms;

namespace travel_app.ViewModels
{
    public class DetalleHotelViewModel : INotifyPropertyChanged
    {
        private ApiService _apiService;
        public ObservableCollection<Hotel> Hoteles { get; set; }
        public ICommand LoadHotelDetailsCommand { get; }

        public DetalleHotelViewModel()
        {
            _apiService = new ApiService();
            Hoteles = new ObservableCollection<Hotel>();

            // Comando para cargar los detalles del hotel
            LoadHotelDetailsCommand = new Command<int>(async (hotelId) => await LoadHotelDetails(hotelId));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Método para cargar los detalles del hotel llamando al servicio
        public async Task LoadHotelDetails(int id)
        {
            try
            {
                // Obtener los detalles del hotel
                var responseObject = await _apiService.GetAsync<Response<Hotel>>($"hotel/{id}");

                // Verificar si se obtuvo un objeto de respuesta válido
                if (responseObject != null && responseObject.Data != null)
                {
                    Hoteles.Clear(); // Limpiar la colección existente
                    Hoteles.Add(responseObject.Data); // Agregar el hotel a la colección
                    Console.WriteLine($"Hotel cargado: {responseObject.Data.Nombre}"); // Imprimir en la consola
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener los detalles del hotel: {ex.Message}");
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Error al deserializar JSON: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw new Exception("Ocurrió un error al cargar los detalles del hotel.", ex);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}