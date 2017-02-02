using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Business.Services.Contracts
{
	public interface IUserHotelService
	{
		IQueryable<UserHotel> GetAllHotels();
		UserHotel GetById(int id);
		UserHotel GetByName(string name);

		HotelLocation GetHotelLocation(UserHotel hotel);

		void AddHotel(UserHotel hotelToAdd);
		void DeleteHotel(UserHotel hotelToDelete);
		void DeleteHotelById(object hotelId);
	}
}
