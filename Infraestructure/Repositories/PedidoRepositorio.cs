using Domain.Entities;
using Domain.Enums;
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
    public class PedidoRepositorio : GenericRepositorio<Pedido>, IPedido
    {
        public PedidoRepositorio(AppDbContexts Context) : base(Context) { }

        public async Task<IEnumerable<Pedido>> GetPedidosPendientesAsync()
        {
            return await _context.Pedidos
                                 .Include(p => p.Detalles) // Traer hamburguesas/productos
                                 .Include(p => p.Comercio) // Traer datos del local
                                 .Where(p => p.Estado == EstadoPedido.Pendiente && p.Activo)
                                 .OrderBy(p => p.FechaCreacion)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> GetPedidosPorClienteAsync(string telefonoCliente)
        {
            return await _context.Pedidos
                                 .Include(p => p.Detalles)
                                 .Where(p => p.TelefonoCliente == telefonoCliente)
                                 .OrderByDescending(p => p.FechaCreacion)
                                 .ToListAsync();
        }

        public async Task<Pedido?> GetPedidoEnCursoPorRepartidorAsync(int repartidorId)
        {
            // Buscamos si el repartidor tiene algo 'EnCamino' o 'Asignado'
            return await _context.Pedidos
                                .Include(p => p.Detalles)
                                .FirstOrDefaultAsync(p =>
                                    p.IdRepartidor == repartidorId &&
                                    (p.Estado == EstadoPedido.EnCamino || p.Estado == EstadoPedido.Asignado)
                                );
        }
    }
}
