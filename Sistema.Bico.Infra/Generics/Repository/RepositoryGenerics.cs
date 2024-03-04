using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Sistema.Bico.Domain.Generics.Interfaces;
using Sistema.Bico.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Sistema.Bico.Infra.Generics.Repository
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositoryGenerics()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task Add(T entity)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                await data.Set<T>().AddAsync(entity);
                await data.SaveChangesAsync();

            }
        }
        public async Task Delete(T entity)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Remove(entity);
                await data.SaveChangesAsync();

            }
        }

        public async Task<T> GetEntityById(Guid id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                   string includeProperties = null)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                IQueryable<T> query = data.Set<T>();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }

                if (orderBy != null)
                {
                    query = orderBy(query);
                }

                return await query.AsNoTracking().ToListAsync();
            }
        }

        public async Task Update(T entity)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Update(entity);
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
