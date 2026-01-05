using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RepartidorRef : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string Telefono {  get; set; } = string.Empty;
        public string NumeroPlaca { get; set; } = string.Empty;
        
        public bool Disponible { get; set; } = true;

        public ICollection<Pedido>? Pedidos { get; set; }

        public int? IdRepartidor { get; set; }
        public RepartidorRef? Repartidor { get; set; }
    }
}
