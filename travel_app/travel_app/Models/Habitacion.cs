using System;
using System.Collections.Generic;
using System.Text;

namespace travel_app.Models
{
    public class Habitacion
    {
        public int Habitacion_Id { get; set; }
        public int Estado { get; set; }
        public int Num_Habitacion { get; set; }
        public int? Reserva_Id { get; set; }
        public TipoHabitacion Tipo_Habitacion { get; set; }
    }
}
