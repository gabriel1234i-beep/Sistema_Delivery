using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IExternoService
    {
        Task<RepartidorRef> ObternerRepartidorPorId(Guid id);
        Task<ComercioRef> ObternerComercioPorId(Guid id);
        Task<List<ComercioRef>> ListarComerciosDisponibles();
    }
}
