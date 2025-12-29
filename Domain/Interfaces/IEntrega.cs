using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;
public interface IEntrega
{
    Task<Entrega> ObtenerPorId(Guid id);
    Task Guardar(Entrega entrega);
}
