using System.Collections.Generic;
using System.Linq;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Business.Services.Contracts
{
    public interface IHotelService
    {
        IList<Hotel> GetHotels(int startAt, int count);

        IQueryable<Hotel> GetAllHotels();

        Hotel GetById(int id);

        HotelLocation GetHotelLocation(Hotel hotel);

        void AddHotel(
            string hotelName, 
            string hotelDescription,
            string hotelManagerId,
		    HotelLocation location, 
            string imageUrl);
    }
}
