using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ubicacion
    {
        public double Latitud {  get; set; }
        public double Longitud { get; set; }

        public string DireccionTexto { get; set; } = string.Empty;
        public string Referencia { get; set; } = string.Empty;
    }
}
