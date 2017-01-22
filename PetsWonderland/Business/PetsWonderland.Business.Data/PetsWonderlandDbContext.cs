using System.Data.Entity;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Data.Migrations;

namespace PetsWonderland.Business.Data
{
    public class PetsWonderlandDbContext : DbContext, IPetsWonderlandDbContext
    {
        public PetsWonderlandDbContext()
                : base("PetsWonderland")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PetsWonderlandDbContext, Configuration>());
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
