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
    public partial class HomePage : FlyoutPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private async void OnhotelesClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HotelesPage());
            IsPresented = false;  // Oculta la barra lateral
        }

        private async void OnreservasClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ReservaPage());
            IsPresented = false;  // Oculta la barra lateral
        }

        private async void OnatracsiClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomePage());
            IsPresented = false;  // Oculta la barra lateral
        }
    }
}
    
    