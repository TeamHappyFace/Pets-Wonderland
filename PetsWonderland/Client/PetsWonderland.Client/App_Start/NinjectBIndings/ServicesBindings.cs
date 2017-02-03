using Ninject.Modules;
using PetsWonderland.Business.Services;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Client.NinjectBIndings
{
    public class ServicesBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAnimalService>().To<AnimalService>();
        }
    }
}