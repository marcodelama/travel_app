using System;
using travel_app.Services;
using Xamarin.Forms;

namespace travel_app.Views
{
    public partial class Inicio : TabbedPage
    {
        private ApiService http;
        public Inicio()
        {
            InitializeComponent();
            http = new ApiService();
        }

        private async void OnIniciarSesionClicked(object sender, EventArgs e)
        {
            // Navega a la vista de Iniciar Sesión
            await Navigation.PushAsync(new LoginPage(http));
        }

        private async void OnRegistrarseClicked(object sender, EventArgs e)
        {
            // Navega a la vista de Registro
            await Navigation.PushAsync(new Registrar());
        }
    }
}
