using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travel_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservaPage : TabbedPage
    {
        public ReservaPage()
        {
            InitializeComponent();
        }
        private async void OnGuardarClicked(object sender, EventArgs e)
        {
            // Lógica para guardar la reserva (si es necesario)

            // Mostrar mensaje de confirmación
            await DisplayAlert("Reserva guardada", "La reserva ha sido guardada correctamente.", "OK");
        }
    }
}