using System.Collections.ObjectModel;
using System.Windows.Input;
using travel_app.Models;
using Xamarin.Forms;

namespace travel_app.ViewModels
{
    public class AtraccionesViewModel : BindableObject
    {
        private ObservableCollection<Atraccion> atracciones;

        public ObservableCollection<Atraccion> Atracciones
        {
            get { return atracciones; }
            set
            {
                atracciones = value;
                OnPropertyChanged();
            }
        }

        public ICommand VerDetallesCommand { get; }

        public AtraccionesViewModel()
        {
            // Inicializar la lista de atracciones
            Atracciones = new ObservableCollection<Atraccion>
            {
                new Atraccion { Nombre = "Atracción A", Descripcion = "Descripción de Atracción A", ImagenUrl = "https://link_a_imagen_a.jpg" },
                new Atraccion { Nombre = "Atracción B", Descripcion = "Descripción de Atracción B", ImagenUrl = "https://link_a_imagen_b.jpg" },
                new Atraccion { Nombre = "Atracción C", Descripcion = "Descripción de Atracción C", ImagenUrl = "https://link_a_imagen_c.jpg" }
            };

            // Inicializar los comandos
            VerDetallesCommand = new Command<Atraccion>(VerDetalles);
        }

        // Método para ver los detalles de una atracción
        private void VerDetalles(Atraccion atraccion)
        {
            // Aquí puedes agregar la lógica para navegar a una página de detalles de la atracción
        }
    }
}
