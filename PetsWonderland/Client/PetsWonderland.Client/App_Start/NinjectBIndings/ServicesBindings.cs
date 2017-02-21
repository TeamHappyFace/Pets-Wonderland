using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace PetsWonderland.Client.NinjectBIndings
{
    public class ServicesBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x.From("PetsWonderland.Business.Services").SelectAllClasses().BindDefaultInterface());
        }
    }
}