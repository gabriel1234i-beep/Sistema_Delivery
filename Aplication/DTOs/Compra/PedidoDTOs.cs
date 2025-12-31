using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs.Compra
{
    public class PedidoDTOs
    {
         public Guid IdCliente { get; set; }
        public Guid IdComercio { get; set; }
        public List<ItemPedidoDTO> Items { get; set; } = new List<ItemPedidoDTO>();
        public DireccionDTOs DireccionEntrega { get; set; } = new DireccionDTOs();
    }

    public class ItemPedidoDTO
    {
        public string Producto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
