using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetallePedido : BaseEntity
    {
        public string NombreProducto {  get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public int IdPedido {  get; set; }
        public Pedido? pedido { get; set;}
    }
}
