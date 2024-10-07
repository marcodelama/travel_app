using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace travel_app.Models
{
    public class TipoHabitacion
    {
        public int Tipo_Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Capacidad { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }



    }
}
