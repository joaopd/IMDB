using Data.Interfaces;
using Dominio.Models.Base;
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
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
    {
        protected readonly ApplicationDbContext _context;
        private DbSet<T> _dataSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task<T> add(T objeto)
        {
            try
            {
                _dataSet.Add(objeto);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objeto;
        }

        public async Task<T> GetEntityById(int Id)
        {
            return await _dataSet.FindAsync(Id);
        }

        public async Task<List<T>> GetDataList(Expression<Func<T, bool>> expression = null,
            Func<System.Linq.IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> qry = _dataSet.AsNoTracking();

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

        public async Task<T> Update(T objeto)
        {
            try
            {
                T result = await _dataSet.FindAsync(objeto.Id);
                if (result == null)
                    return null;

                _context.Entry(result).CurrentValues.SetValues(objeto);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objeto;
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
