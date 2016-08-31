using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFlota.Forms.DataObjects
{
    public class Vehiculo
    {
        public string Id { get; set; }
        public string Placas { get; set; }
        //public Empresa Empresa { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Consesionario { get; set; }
        public float ValorCompra { get; set; }
        public string Matricula { get; set; }
        public DateTime fechaMatricula { get; set; }
        public int Kilometraje { get; set; }
    }
}
