using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // exponemos las interfaces especificas
        IPedido Pedido { get; }
        IRepartidor Repartidor { get; }
        IComercio Comercio { get; }

        //metodo para guardar en la BD
        Task<int> SaveAsync();
    }
}
