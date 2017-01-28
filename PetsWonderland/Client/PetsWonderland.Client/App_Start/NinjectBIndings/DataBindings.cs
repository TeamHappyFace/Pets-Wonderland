using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Modules;
using PetsWonderland.Business.Data;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Data.Repositories;
using PetsWonderland.Business.Data.UnitOfWork;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Client.NinjectBIndings
{
    public class DataBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            this.Bind<IPetsWonderlandDbContext>().To<PetsWonderlandDbContext>().InSingletonScope();           
            this.Bind<IUnitOfWork>().To<UnitOfWork>();

			//this.Bind<IUserStore<UserProfile>>().To<UserStore<UserProfile>>();
			//this.Bind<UserManager<UserProfile>>().ToSelf();
		}
    }
}