using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class ComercioRepositorio : GenericRepositorio<ComercioRef>, IComercio
    {
        public ComercioRepositorio(AppDbContexts context) : base(context) { }

        public async Task<IEnumerable<ComercioRef>> GetComercioCategoriaAsync(string categoria)
        {
            return await _context.Comercios
                                 .Where(c => c.Categoria == categoria && c.Activo)
            .ToListAsync();
        }

        public async Task<IEnumerable<ComercioRef>> GetComercioCercanoAsync(double latitud, double longitud)
        {
            // MOCK LÓGICO / SIMULACIÓN:
            // En un entorno de producción real, aquí usaríamos NetTopologySuite o SQL Spatial 
            // para calcular la distancia en metros.
            // Para tu sistema de prueba, retornaremos todos los comercios activos.

            return await _context.Comercios
                                 .Where(c => c.Activo)
                                 .ToListAsync();
        }
    }
}
