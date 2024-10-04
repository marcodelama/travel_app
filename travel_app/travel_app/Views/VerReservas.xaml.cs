using Xamarin.Forms;
using travel_app.ViewModels;

namespace travel_app.Views
{
    public partial class VerReservas : ContentPage
    {
        public VerReservas()
        {
            InitializeComponent();
            BindingContext = new VerReservasViewModel(); // Asegúrate de que esto esté aquí
        }
    }
}
