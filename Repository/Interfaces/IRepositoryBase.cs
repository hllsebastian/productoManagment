using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> Queries();
        T QueryById(Expression<Func<T, bool>> predicate);
        IQueryable<T> QueryBy(Expression<Func<T, bool>> predicate);
        Task Create(T model);
        Task Upload(T model);
        Task Delete(T model);
    }
}
