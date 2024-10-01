using System;
using Xamarin.Forms;

namespace travel_app.Views
{
    public partial class IniciarSesion : TabbedPage
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }

        // Método que manejará el evento Clicked del botón
        private void OnhomeClicked(object sender, EventArgs e)
        {
            // Aquí puedes implementar la lógica de inicio de sesión
            // Por ejemplo, puedes verificar las credenciales ingresadas
            // y navegar a otra página o mostrar un mensaje.

            DisplayAlert("Iniciar Sesión", "Se ha hecho clic en el botón de iniciar sesión", "OK");
        }
    }
}
