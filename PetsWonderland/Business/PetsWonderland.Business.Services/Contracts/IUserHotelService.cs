using System.Linq;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Business.Services.Contracts
{
	public interface IUserHotelService
	{
		IQueryable<UserHotel> GetAllUserHotels();
		UserHotel GetById(int id);
		UserHotel GetByName(string name);

		HotelLocation GetUserHotelLocation(UserHotel hotel);

		void AddUserHotel(UserHotel hotelToAdd);
		void DeleteUserHotel(UserHotel hotelToDelete);
		void DeleteUserHotelById(object hotelId);
	}
}
