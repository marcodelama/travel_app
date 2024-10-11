using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using travel_app.Models;
using Xamarin.Forms;

namespace travel_app.ViewModels
{
    public class ReservaViewModel
    {
        public string Nombre { get; }
        public string Descripcion { get; }
        public decimal Precio { get; }

        public ReservaViewModel(Habitacion habitacion)
        {
            Nombre = habitacion.Tipo_Habitacion.Nombre;
            Descripcion = habitacion.Tipo_Habitacion.Descripcion;
            Precio = habitacion.Tipo_Habitacion.Precio;
        }
    }
}
