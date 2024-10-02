using System;
using System.Collections.Generic;
using System.Text;

namespace travel_app.Models
{
    public class Cliente
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
    }
}
