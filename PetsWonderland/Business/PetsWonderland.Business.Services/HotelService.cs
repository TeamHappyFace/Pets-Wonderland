using System.Linq;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
	public class HotelService : IHotelService
	{
        private readonly IRepository<Hotel> hotelRepository;

		public HotelService(IRepository<Hotel> hotelRepository)
		{
			this.hotelRepository = hotelRepository;
		}

		public void AddHotel(Hotel hotelToAdd)
		{
			this.hotelRepository.Add(hotelToAdd);
		}

		public void DeleteHotel(Hotel hotelToDelete)
		{
			this.hotelRepository.Delete(hotelToDelete);
		}

		public void DeleteHotelById(object hotelId)
		{
			this.hotelRepository.Delete(hotelId);
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
