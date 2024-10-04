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
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private async void OnHotelesTapped(object sender, EventArgs e)
        {
            // Navega a la página de hoteles
            await Navigation.PushAsync(new HotelesPage());
        }
    }
}