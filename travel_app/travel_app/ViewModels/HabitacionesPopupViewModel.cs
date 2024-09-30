using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace travel_app.ViewModels
{
    public class HabitacionesPopupViewModel
    {
        public ICommand CerrarPopupCommand { get; }
        public HabitacionesPopupViewModel()
        {
            CerrarPopupCommand = new Command(async () => await PopupNavigation.Instance.PopAsync());
        }
    }
}
