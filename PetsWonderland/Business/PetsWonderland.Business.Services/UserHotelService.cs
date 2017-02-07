using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
	public class UserHotelService : IUserHotelService
	{
		private readonly IRepository<UserHotel> userHotelRepository;
		private readonly IUnitOfWork unitOfWork;

		public UserHotelService(IRepository<UserHotel> userHotelRepository, IUnitOfWork unitOfWork)
		{
			Guard.WhenArgument(userHotelRepository, "User hotel repository is null!").IsNull();
			Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull();

			this.userHotelRepository = userHotelRepository;
			this.unitOfWork = unitOfWork;
		}

		public void AddHotel(UserHotel hotelToAdd)
		{
			Guard.WhenArgument(hotelToAdd, "User hotel to add is null!").IsNull();

			this.userHotelRepository.Add(hotelToAdd);
			this.unitOfWork.SaveChanges();
		}

		public void DeleteHotel(UserHotel hotelToDelete)
		{
			Guard.WhenArgument(hotelToDelete, "User hotel to delete is null!").IsNull();

			this.userHotelRepository.Delete(hotelToDelete);
			this.unitOfWork.SaveChanges();
		}

		public void DeleteHotelById(object hotelId)
		{
			Guard.WhenArgument(hotelId, "Cannot delete user hotel with id=null!").IsNull();

			this.userHotelRepository.Delete(hotelId);
			this.unitOfWork.SaveChanges();
		}

		public IQueryable<UserHotel> GetAllHotels()
		{
			return this.userHotelRepository.All();
		}

		public UserHotel GetById(int id)
		{
			return this.userHotelRepository.GetById(id);
		}

		public UserHotel GetByName(string name)
		{
			return this.userHotelRepository.GetByName(name);
		}

		public HotelLocation GetHotelLocation(UserHotel hotel)
		{
			return hotel.Hotel.Location;
		}
	}
}
