using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PetsWonderland.Business.Data.Contracts
{
    public interface IPetsWonderlandDbContext : IDisposable
    {
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void SaveChanges();
    }
}