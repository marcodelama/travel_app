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
        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            // Redirige a la página principal
            await Navigation.PushAsync(new HomePage());
        }
    }
}
