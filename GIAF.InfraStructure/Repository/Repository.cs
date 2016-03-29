using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIAF.InfraStructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext Context { get { return UnitOfWork.UnitOfWork.Current.Context; } }

        public void Add(T entity)
        {
            this.Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return this.Context.Set<T>().Where(predicate).AsQueryable();
        }

        public IQueryable<T> GetWith(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params string[] includededEntities)
        {
            var query = this.Context.Set<T>().AsQueryable<T>();

            foreach (var fk in includededEntities)
            {
                query = query.Include(fk);
            }

            return query.Where(predicate);
        }

        public IQueryable<T> GetWith(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params System.Linq.Expressions.Expression<Func<T, object>>[] includededEntities)
        {
            if (includededEntities.Count() > 0)
            {
                var query = this.Context.Set<T>().Where(predicate);

                foreach (var fk in includededEntities)
                {
                    query = query.Include(fk);
                }

                return query.AsQueryable();
            }
            return this.Context.Set<T>().Where(predicate).AsQueryable();
        }

        public DbSet<T> Set()
        {
            return this.Context.Set<T>();
        }

        public void UpdateInstantly(T entity)
        {
            this.Context.SaveChanges();
        }
    }
}
