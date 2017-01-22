using System.Data.Entity.Migrations;

namespace PetsWonderland.Business.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<PetsWonderlandDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }      
    }
}
