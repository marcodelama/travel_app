using Xamarin.Forms;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace travel_app.Views
{
    public partial class Registrar : ContentPage
    {
        public Registrar()
        {
            InitializeComponent();
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

                var json = JsonConvert.SerializeObject(clienteData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    // Establecer la URL base
                    client.BaseAddress = new Uri("http://localhost:4000"); // Cambia esto a la URL de tu servidor
                    var response = await client.PostAsync("usuario/cliente/create", content);
                    if (response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Éxito", "Usuario registrado exitosamente.", "OK");
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        await DisplayAlert("Error", errorMessage, "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

    }
}

