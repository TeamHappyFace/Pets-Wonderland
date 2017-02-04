using System.Linq;
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
			this.userHotelRepository = userHotelRepository;
			this.unitOfWork = unitOfWork;
		}

		public void AddHotel(UserHotel hotelToAdd)
		{
			this.userHotelRepository.Add(hotelToAdd);
			this.unitOfWork.SaveChanges();
		}

		public void DeleteHotel(UserHotel hotelToDelete)
		{
			this.userHotelRepository.Delete(hotelToDelete);
			this.unitOfWork.SaveChanges();
		}

		public void DeleteHotelById(object hotelId)
		{
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
			return hotel.Hotel.HotelLocation;
		}
	}
}
