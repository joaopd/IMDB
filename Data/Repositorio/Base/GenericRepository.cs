using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ApplicationDbContext> _optionsBuilder;

        public GenericRepository()
        {
            _optionsBuilder = new DbContextOptions<ApplicationDbContext>();
        }

        public async Task add(T objeto)
        {
            using (ApplicationDbContext data = new ApplicationDbContext(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int Id)
        {
            using (ApplicationDbContext data = new ApplicationDbContext(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task<List<T>> List(Expression<Func<T, bool>> expression = null,
            Func<System.Linq.IQueryable<T>, IIncludableQueryable<T, object>> include = null
)
        {
            using (ApplicationDbContext data = new ApplicationDbContext(_optionsBuilder))
            {
                IQueryable<T> qry = data.Set<T>().AsNoTracking();

                if (expression != null)
                {
                    qry = qry.Where(expression);
                }
                if (include != null)
                {
                    qry = include(qry);
                }

                return await qry.ToListAsync();
            }
        }

        public async Task Update(T objeto)
        {
            using (ApplicationDbContext data = new ApplicationDbContext(_optionsBuilder))
            {
                data.Set<T>().Update(objeto);
                await data.SaveChangesAsync();
            }
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
