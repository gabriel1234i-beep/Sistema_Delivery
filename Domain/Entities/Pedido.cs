using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public Guid IdCliente { get; private set; }
        public Guid IdComercio { get; private set; }
        public List<ItemPedido> Items { get; private set; } = new();
        public decimal PagoTotal { get; private set; }
        public Direccion DireccionEntrega { get; private set; }
        public EstadoPedido Estado { get; private set; }
        public Guid? IdRepartidor { get; private set; }

        //private Pedido() { }

        public Pedido(Guid Idcliente, Guid Idcomercio, Direccion entrega)
        {
            IdCliente = Idcliente;
            IdComercio = Idcomercio;
            DireccionEntrega = entrega;
            Estado = EstadoPedido.Pendiente;
        }

        public void AgregarItem(string producto, int cantidad, decimal precio)
        {
            Items.Add(new ItemPedido(producto, cantidad, precio));
            PagoTotal = Items.Sum(x => x.SubTotal);
        }
    }
}
