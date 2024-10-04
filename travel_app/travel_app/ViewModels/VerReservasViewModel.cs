using System.Collections.ObjectModel;
using System.Windows.Input;
using travel_app.Models;
using Xamarin.Forms;

namespace travel_app.ViewModels
{
    public class VerReservasViewModel : BindableObject
    {
        private ObservableCollection<Reserva> reservas;

        public ObservableCollection<Reserva> Reservas
        {
            get { return reservas; }
            set
            {
                reservas = value;
                OnPropertyChanged();
            }
        }

        public ICommand CancelarReservaCommand { get; }
        public ICommand VerDetallesCommand { get; }

        public VerReservasViewModel()
        {
            System.Diagnostics.Debug.WriteLine("VerReservasViewModel Constructor Invoked");

            // Inicializar la lista de reservas
            Reservas = new ObservableCollection<Reserva>
    {
        new Reserva { NombreHotel = "Hotel A", Descripcion = "Descrip. Hotel A", ImagenUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/1b/91/14/da/sonesta-posadas-del-inca.jpg?w=1200&h=-1&s=1" },
        new Reserva { NombreHotel = "Hotel B", Descripcion = "Descrip. Hotel B", ImagenUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/1b/91/14/da/sonesta-posadas-del-inca.jpg?w=1200&h=-1&s=1" },
        new Reserva { NombreHotel = "Hotel C", Descripcion = "Descrip. Hotel C", ImagenUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/1b/91/14/da/sonesta-posadas-del-inca.jpg?w=1200&h=-1&s=1" }
    };


            // Inicializar los comandos
            CancelarReservaCommand = new Command<Reserva>(CancelarReserva);
            VerDetallesCommand = new Command<Reserva>(VerDetalles);
        }

        // Método para cancelar una reserva
        private void CancelarReserva(Reserva reserva)
        {
            // Aquí puedes agregar la lógica para cancelar la reserva
            Reservas.Remove(reserva);
        }

        // Método para ver los detalles de una reserva
        private void VerDetalles(Reserva reserva)
        {
            // Aquí puedes agregar la lógica para navegar a una página de detalles de la reserva
            // Ejemplo: await Application.Current.MainPage.Navigation.PushAsync(new DetallesReservaPage(reserva));
        }
    }
}
