using ApiProductManagment.ModelsUpdate;
using ApiProductManagment.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiProductManagment.Repository.RepositoryBase
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {

        public CupboardContext DataBaseContext { get; set; }

        public RepositoryBase(CupboardContext context)
        {
            DataBaseContext = context;
        }


        public IQueryable<T> Queries()
        {
            var setModel = DataBaseContext.Set<T>();
            return setModel.AsQueryable();
        }

        public T QueryById(Expression<Func<T, bool>> predicate)
        {
            return Queries().FirstOrDefault(predicate);
        }

        public async Task Create(T model)
        {
            await DataBaseContext.AddAsync(model);
            await DataBaseContext.SaveChangesAsync();
        }

        public IQueryable<T> QueryBy(Expression<Func<T, bool>> predicate)
        {
            return Queries().Where(predicate);
        }

        public async Task Upload(T model)
        {
            DataBaseContext.Update(model);
            await DataBaseContext.SaveChangesAsync();
        }

        public async Task Delete(T model)
        {
            DataBaseContext.Remove(model);
            await DataBaseContext.SaveChangesAsync();
        }

       

       

        

      
    }
}
