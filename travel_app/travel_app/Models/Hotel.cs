using System;
using System.Collections.Generic;
using System.Text;

namespace travel_app.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Valoracion { get; set; }
        public string Imagen { get; set; }
        public int Provincia_id { get; set; }
    }
}
