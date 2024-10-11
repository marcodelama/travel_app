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

            await Navigation.PushAsync(new HotelesPage());
        }
        private async void OnMachuPichuTapped(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Lugares());
        }
    }
}