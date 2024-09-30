using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using travel_app.Models;
using travel_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travel_app.Views.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HabitacionesPopup : PopupPage
    {
        public HabitacionesPopup()
        {
            InitializeComponent();
            BindingContext = new HabitacionesPopupViewModel();
        }
    }
}