using System.Linq;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
	public class HotelService : IHotelService
	{
        private readonly IRepository<Hotel> hotelRepository;
		private readonly IUnitOfWork unitOfWork;

		public HotelService(IRepository<Hotel> hotelRepository, IUnitOfWork unitOfWork)
		{
			this.hotelRepository = hotelRepository;
			this.unitOfWork = unitOfWork;
		}

		public void AddHotel(Hotel hotelToAdd)
		{
			this.hotelRepository.Add(hotelToAdd);
			this.unitOfWork.SaveChanges();
		}

		public void DeleteHotel(Hotel hotelToDelete)
		{
			this.hotelRepository.Delete(hotelToDelete);
			this.unitOfWork.SaveChanges();
		}

		public void DeleteHotelById(object hotelId)
		{
			this.hotelRepository.Delete(hotelId);
			this.unitOfWork.SaveChanges();
		}

		public IQueryable<Hotel> GetAllHotels()
		{
			return this.hotelRepository.All();
		}

		public Hotel GetById(int id)
		{
			return this.hotelRepository.GetById(id);
		}

		public Hotel GetByName(string name)
		{
			return this.hotelRepository.GetByName(name);
		}

		public HotelLocation GetHotelLocation(Hotel hotel)
		{
			return hotel.HotelLocation;
		}
	}
}
