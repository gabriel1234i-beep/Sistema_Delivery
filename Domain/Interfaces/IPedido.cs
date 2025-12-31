using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPedido
    {
        Task<IEnumerable<IPedido>> All();
        Task<Pedido> ObtenerPorId(Guid id);
        Task<List<Pedido>> ObtenerTodos();
        Task Crear(Pedido pedido);
        Task Guardar(Pedido pedido);
        Task Actualizar(Pedido pedido);
    }
}
