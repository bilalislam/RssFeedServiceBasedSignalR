using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GIAF.InfraStructure.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetWith(Expression<Func<T, bool>> predicate, params string[] includededEntities);
        IQueryable<T> GetWith(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includededEntities);        

        void UpdateInstantly(T entity);
    }
}
