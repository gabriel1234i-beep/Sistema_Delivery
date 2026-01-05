using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepartidor : IGeneric<RepartidorRef>
    {
        //para validar si el repartidor existe en el sistema externo antes de asignarle un pedido
        Task<bool> ExisteRepartidorAsync(int idExterno);

        //obtener solo repartidores que esten activos y disponibles
        Task<IEnumerable<RepartidorRef>> GetRepartidorDisponibleAsync();
    }
}
