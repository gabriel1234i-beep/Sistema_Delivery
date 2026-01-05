using Domain.Interfaces;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContexts _context;

        // Propiedades que exponemos para usar en los UseCases
        public IPedido Pedido { get; private set; }
        public IComercio Comercio { get; private set; }
        public IRepartidor Repartidor { get; private set; }

        public UnitOfWork(AppDbContexts context)
        {
            _context = context;

            // Inicializamos los repositorios concretos
            Pedido = new PedidoRepositorio(_context);
            Comercio = new ComercioRepositorio(_context);
            Repartidor = new RepartidorRepositorio(_context);
        }

        public async Task<int> SaveAsync()
        {
            // Guarda todos los cambios en memoria de todos los repositorios a la vez
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
