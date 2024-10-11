using Newtonsoft.Json;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using travel_app.Models;
using travel_app.Services;
using travel_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travel_app.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReservaPopup : PopupPage
	{
        private List<Habitacion> habitacionesSeleccionadas;
        private ApiService apiService;
        public ReservaPopup(List<Habitacion> habitaciones)
        {
            InitializeComponent();
            BindingContext = new { Habitaciones = habitaciones };
            habitacionesSeleccionadas = habitaciones;
            apiService = new ApiService();
        }
        private void OnHabitacionCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            var habitacion = (checkBox.BindingContext as Habitacion);

            if (habitacion != null)
            {
                if (e.Value) // Si el checkbox está marcado
                {
                    habitacionesSeleccionadas.Add(habitacion);
                }
                else // Si el checkbox está desmarcado
                {
                    habitacionesSeleccionadas.Remove(habitacion);
                }
            }
        }
        private async void Cerrar_Popup(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(); // Cerrar el popup
        }
        private async void OnClickedReservar(object sender, EventArgs e)
        {
            var fechaInicio = FechaInicioPicker.Date.ToString("yyyy-MM-dd");
            var fechaFin = FechaFinPicker.Date.ToString("yyyy-MM-dd");

            // Filtrar los IDs de las habitaciones seleccionadas
            var habitacionIds = habitacionesSeleccionadas.Select(h => h.Habitacion_Id).ToList();

            // Crear listas proporcionales a las habitaciones seleccionadas
            var fechas_inicio = new List<string>();
            var fechas_fin = new List<string>();

            for (int i = 0; i < habitacionIds.Count; i++)
            {
                // Cada habitación tendrá una fecha única proporcional
                var fechaInicioHabitacion = FechaInicioPicker.Date.AddDays(i).ToString("yyyy-MM-dd");
                var fechaFinHabitacion = FechaFinPicker.Date.AddDays(i).ToString("yyyy-MM-dd");

                fechas_inicio.Add(fechaInicioHabitacion);
                fechas_fin.Add(fechaFinHabitacion);
            }

            // Crear el objeto JSON para enviar
            var reserva = new
            {
                usuario_id = 2, // Aquí puedes cambiar el ID del usuario
                fecha_creacion = DateTime.Now.ToString("yyyy-MM-dd"),
                fechas_inicio = fechas_inicio,
                fechas_fin = fechas_fin,
                metodo_pago = "crédito",
                habitacion_ids = habitacionIds
            };


            var response = await apiService.PostAsync("reserva/create", reserva);
                
                await DisplayAlert("Éxito", "Reserva realizada con éxito", "OK");
                await PopupNavigation.Instance.PopAsync();
        }
    }
}