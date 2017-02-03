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
			this.Bind<IHotelService>().To<HotelService>();
			this.Bind<IUserHotelService>().To<UserHotelService>();
			this.Bind<IHotelRegistrationRequestService>().To<HotelRegistrationRequestService>();
			this.Bind<IBoardingRequestService>().To<BoardingRequestService>();
        }
    }
}