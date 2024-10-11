using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
        public ICommand VerHabitacionesCommand { get; }
        public DetalleHotelViewModel()
        {
            _apiService = new ApiService();
            Hoteles = new ObservableCollection<Hotel>();
            LoadHotelDetailsCommand = new Command<int>(async (hotelId) => await LoadHotelDetails(hotelId));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task LoadHotelDetails(int id)
        {
            Debug.WriteLine("id", id);
            var responseObject = await _apiService.GetAsync<Response<Hotel>>($"hotel/{id}");

            string jsonResponse = JsonConvert.SerializeObject(responseObject, Formatting.Indented);
            Debug.WriteLine($"Respuesta completa:\n{jsonResponse}");

            if (responseObject != null && responseObject.Data != null)
            {
                Hoteles.Clear();
                Hoteles.Add(responseObject.Data);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}