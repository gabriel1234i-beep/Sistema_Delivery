using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ComercioRef
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public Direccion? Ubicacion { get; set; }
    }
}
