using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contracts.Repository;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected EvaExchangeContext EvaExchangeContext;

        public BaseRepository(EvaExchangeContext evaExchangeContext)
        {
            EvaExchangeContext = evaExchangeContext;
        }
        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges
           ? EvaExchangeContext.Set<T>().AsNoTracking()
           : EvaExchangeContext.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges
            ? EvaExchangeContext.Set<T>().Where(expression).AsNoTracking()
            : EvaExchangeContext.Set<T>().Where(expression);
        public void Create(T entity) => EvaExchangeContext.Set<T>().Add(entity);
        public void Update(T entiy) => EvaExchangeContext.Set<T>().Update(entiy);
        public void Delete(T entiy) => EvaExchangeContext.Set<T>().Remove(entiy);
    }
}
