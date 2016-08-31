using System;
using System.Collections.Generic;

namespace iFlota.Forms.DataObjects
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Foto { get; set; }
        public string Conector { get; set; }
        public bool Bloqueado { get; set; }
        public List<Vehiculo> Vehiculos { get; set; }
    }
}
