using Domain.Common;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class GenericRepositorio<T> : IGeneric<T> where T : BaseEntity
    {
        protected readonly AppDbContexts _context;

        public GenericRepositorio(AppDbContexts context)
        {
            _context = context;
        }

        public async Task<T?> GetByAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(x => x.Activo).ToListAsync();
        }

        public async Task<IEnumerable<T>> FinAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            entity.Activo = false;
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
