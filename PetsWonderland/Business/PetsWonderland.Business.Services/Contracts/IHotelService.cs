using System.Linq;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Business.Services.Contracts
{
	public interface IHotelService
	{
		IQueryable<Hotel> GetAllHotels();
		Hotel GetById(int id);
		Hotel GetByName(string name);

		HotelLocation GetHotelLocation(Hotel hotel);

		void AddHotel(Hotel hotelToAdd);
		void DeleteHotel(Hotel hotelToDelete);
		void DeleteHotelById(object hotelId);
	}
}
