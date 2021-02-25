using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Infrastructure
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private ShoppingContext context;

        public GenericRepository(ShoppingContext context)
        {
            this.context = context;
        }

        public virtual T Add(T entity)
        {
            return context.Add(entity).Entity;
        }

        public virtual IEnumerable<T> All()
        {
            return context.Set<T>().ToList();
        }

        public virtual IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .AsQueryable()
                .Where(predicate);
        }

        public virtual T Get(Guid id)
        {
            return context.Find<T>(id);
        }

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            return context.Update<T>(entity).Entity;
        }
    }
}
