using System;
using Xamarin.Forms;

namespace travel_app.Views
{
    public partial class Inicio : TabbedPage
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private async void OnIniciarSesionClicked(object sender, EventArgs e)
        {
            // Navega a la vista de Iniciar Sesión
            await Navigation.PushAsync(new IniciarSesion());
        }

        private async void OnRegistrarseClicked(object sender, EventArgs e)
        {
            // Navega a la vista de Registro
            await Navigation.PushAsync(new Registrar());
        }
    }
}
