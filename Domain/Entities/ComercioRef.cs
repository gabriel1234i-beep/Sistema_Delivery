using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ComercioRef : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string Categoria {  get; set; } = string.Empty;

        public Ubicacion? UbicacionLocal { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
