using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;

namespace PetsWonderland.Business.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPetsWonderlandDbContext context;

        public UnitOfWork(IPetsWonderlandDbContext context)
        {
			Guard.WhenArgument(context, "Db context is null!").IsNull();

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
