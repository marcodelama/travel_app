using Xamarin.Forms;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using travel_app.Models;
using travel_app.Services;

namespace travel_app.Views
{
    public partial class Registrar : ContentPage
    {
        public ApiService apiService;
        public Registrar()
        {
            InitializeComponent();
            apiService = new ApiService();
        }

        private async void OnRegistrarClicked(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén completos
                if (string.IsNullOrWhiteSpace(nombreEntry.Text) ||
                    string.IsNullOrWhiteSpace(apellidoEntry.Text) ||
                    string.IsNullOrWhiteSpace(dniEntry.Text) ||
                    string.IsNullOrWhiteSpace(telefonoEntry.Text) ||
                    string.IsNullOrWhiteSpace(correoEntry.Text) ||
                    string.IsNullOrWhiteSpace(contraseñaEntry.Text))
                {
                    await DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
                    return;
                }

                // Crear el objeto con los datos del cliente
                var clienteData = new
                {
                    num_dni = dniEntry.Text,
                    nombre = nombreEntry.Text,
                    apellido = apellidoEntry.Text,
                    username = correoEntry.Text,
                    password = contraseñaEntry.Text,
                    telefono = telefonoEntry.Text
                };

                var resultado = await apiService.PostAsync("usuario/cliente/create", clienteData);

                await DisplayAlert("Éxito", $"Usuario registrado: {resultado.Mensaje}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

    }
}

