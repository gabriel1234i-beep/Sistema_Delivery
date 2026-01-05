using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // usamos T donde T debe ser una entidad hija de BaseEntety
    public interface IGeneric<T> where T : BaseEntity
    {
        Task<T?> GetByAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        //este metodo servira para filtros personalizados
        Task<IEnumerable<T>> FinAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
