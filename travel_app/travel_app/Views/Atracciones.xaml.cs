using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using travel_app.ViewModels;

namespace travel_app.Views
{
    public partial class Atracciones : ContentPage
    {
        public Atracciones()
        {
            InitializeComponent();
            BindingContext = new AtraccionesViewModel();
        }
    }
}
