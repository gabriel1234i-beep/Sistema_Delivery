using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IComercio : IGeneric<ComercioRef>
    {
        //buscar comercio por categoria
        Task<IEnumerable<ComercioRef>> GetComercioCategoriaAsync(string categoria);

        //buscar comercio cercanos a una ubicacion
        Task<IEnumerable<ComercioRef>> GetComercioCercanoAsync(double latitud, double longitud);
    }
}
