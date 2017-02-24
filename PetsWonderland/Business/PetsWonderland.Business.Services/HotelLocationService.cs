using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
    public class HotelLocationService : IHotelLocationService
    {
        private readonly IRepository<HotelLocation> hotelLocationRepository;
        private readonly IUnitOfWork unitOfWork;

        public HotelLocationService(IRepository<HotelLocation> hotelLocationRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(hotelLocationRepository, "Hotel location repository is null!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

            this.hotelLocationRepository = hotelLocationRepository;
            this.unitOfWork = unitOfWork;
        }

        public HotelLocation AddHotelLocation(string location)
        {
            Guard.WhenArgument(location, "Hotel location to add is null!").IsNull().Throw();

			var locationToAdd = new HotelLocation() { Address = location };

			using (var unitOfWork = this.unitOfWork)
            {
                this.hotelLocationRepository.Add(locationToAdd);
                unitOfWork.SaveChanges();
            }

			return locationToAdd;
        }

        public HotelLocation GetById(int id)
        {
            return this.hotelLocationRepository.GetById(id);
        }

        public HotelLocation GetByAddress(string address)
        {
            return this.hotelLocationRepository.GetFirst(location => location.Address == address);
        }
    }
}
