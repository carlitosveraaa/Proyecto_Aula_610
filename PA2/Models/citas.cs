using System;

namespace PA2.Models
{
    public class Citas
    {
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Ocupado { get; set; }
    }
}
