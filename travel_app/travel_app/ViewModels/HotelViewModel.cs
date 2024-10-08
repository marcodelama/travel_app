﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
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
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }
                };

                var responseObject = await _apiService.GetAsync<ResponseWrapper<Hotel>>("hoteles");

                if (responseObject != null && responseObject.Data != null)
                {
                    Hoteles.Clear();
                    foreach (var hotel in responseObject.Data)
                    {
                        Hoteles.Add(hotel);
                    }
                    string jsonResponse = JsonConvert.SerializeObject(responseObject, Formatting.Indented);
                    Debug.WriteLine($"Respuesta completa:\n{jsonResponse}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener hoteles: {ex.Message}");
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Error al deserializar JSON: {jsonEx.Message}");
            }
        }
    }
}
