using System;
using PetsWonderland.Business.Data.Contracts;

namespace PetsWonderland.Business.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPetsWonderlandDbContext context;

        public UnitOfWork(IPetsWonderlandDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use the unit of work.", nameof(context));
            }

            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }      
    }
}
