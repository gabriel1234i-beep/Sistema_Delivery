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
    public class PedidoRepositorio:IPedido
    {
        private readonly AppDbContexts _context;

        public PedidoRepositorio(AppDbContexts context)
        {
            _context = context;
        }

        public Task Actualizar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pedido>> All()
        {
            return await _context.pedidos.ToListAsync();
        }

        public async Task Crear(Pedido pedido)
        {
            _context.pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public Task<Pedido> ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Pedido>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
