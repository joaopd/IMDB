using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task add(T objeto);
        Task Update(T objeto);
        Task<T> GetEntityById(int Id);
        Task<List<T>> List(Expression<Func<T, bool>> expression = null,
                           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
