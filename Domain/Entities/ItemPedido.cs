using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ItemPedido : BaseEntity
    {
        public string Producto { get; private set; }
        public int Cantidad { get; private set; }
        public decimal Precio { get; private set; }
        public decimal SubTotal => Cantidad * Precio;

        //private ItemPedido() { }

        public ItemPedido(string producto, int cantidad, decimal precio)
        {
            Producto = producto;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
