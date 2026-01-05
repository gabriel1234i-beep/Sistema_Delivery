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
    public class RepartidorRepositorio : GenericRepositorio<RepartidorRef>, IRepartidor
    {
        public RepartidorRepositorio(AppDbContexts context) : base(context) { }

        public async Task<bool> ExisteRepartidorAsync(int idExterno)
        {
            // Verifica si el ID existe en la tabla local sincronizada
            return await _context.Repartidores
                                 .AnyAsync(r => r.Id == idExterno && r.Activo);
        }

        public async Task<IEnumerable<RepartidorRef>> GetRepartidorDisponibleAsync()
        {
            // Retorna repartidores que estén activos (sistema) y disponibles (bandera del conductor)
            return await _context.Repartidores
                                 .Where(r => r.Disponible && r.Activo)
                                 .ToListAsync();
        }
    }
}
