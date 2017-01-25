using System;
using System.Data.Entity;
using System.Linq;
using PetsWonderland.Business.Data.Contracts;

namespace PetsWonderland.Business.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        private readonly IPetsWonderlandDbContext context;
        private readonly IDbSet<T> dbSet;

        public GenericRepository(IPetsWonderlandDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.context = context;    
            this.dbSet = this.context.Set<T>();           
        }

        public IQueryable<T> Entities
        {
            get { return this.dbSet; }
        }

        public virtual IQueryable<T> All()
        {
            return this.Entities;
        }

        public virtual T GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.dbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.dbSet.Attach(entity);
                this.dbSet.Remove(entity);
            }
        }

        public virtual void Delete(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Detach(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }
    }
}
