using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEntrega
    {
        Task<IEnumerable<Entrega>>All();
        Task<Entrega> ObtenerPorId(Guid id);
        Task Crear(Entrega entrega);
        Task Actualizar(Entrega entrega);
        Task Guardar(Entrega entrega);
    }
}
