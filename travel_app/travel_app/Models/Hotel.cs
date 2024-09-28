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
        public int Valoracion { get; set; }
        public string Imagen { get; set; }
    }
    public class ResponseWrapper<T>
    {
        public List<T> Data { get; set; }
    }
    public class Response<T>
    {
        public T Data { get; set; } // Cambiar de List<T> a T
    }
}
