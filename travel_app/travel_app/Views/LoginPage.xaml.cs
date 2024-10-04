using System;
using System.Net.Http;
using travel_app.Services;
using Xamarin.Forms;

namespace travel_app.Views
{
    public partial class LoginPage : TabbedPage
    {
        public LoginPage(ApiService http)
        {
            InitializeComponent();
        }

        // Método que manejará el evento Clicked del botón
        private void OnhomeClicked(object sender, EventArgs e)
        {
            
            DisplayAlert("Iniciar Sesión", "Se ha hecho clic en el botón de iniciar sesión", "OK");
        }
    }
}
