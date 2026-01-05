using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPedido : IGeneric<Pedido>
    {
        //obtener pedidos que aun no tienen repartidor (estado = Pendientes)
        Task<IEnumerable<Pedido>> GetPedidosPendientesAsync();

        //obtener historial de pedidos de un cliente
        Task<IEnumerable<Pedido>> GetPedidosPorClienteAsync(string telefonoCliente);

        //obtener el pedido actual que esta llevando un repartidor (estado = EnCamino)
        Task<Pedido?> GetPedidoEnCursoPorRepartidorAsync(int repartidorId);
    }
}
