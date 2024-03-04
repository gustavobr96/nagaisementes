﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.Generics.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetEntityById(Guid id);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                   string includeProperties = null);
    }
}
