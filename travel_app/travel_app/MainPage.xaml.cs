using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travel_app.Views;
using Xamarin.Forms;

namespace travel_app
{
    public partial class MainPage : FlyoutPage
    {
        public Command ToggleFlyoutCommand { get; set; }

        public MainPage()
        {
            InitializeComponent();
            ToggleFlyoutCommand = new Command(() => IsPresented = !IsPresented);
            BindingContext = this;
        }
    }
}