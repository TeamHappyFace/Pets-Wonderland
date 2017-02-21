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

        Hotel GetByName(string name);

        HotelLocation GetHotelLocation(Hotel hotel);

        int Count();

        void AddHotel(Hotel hotelToAdd);

        void DeleteHotel(Hotel hotelToDelete);

        void DeleteHotelById(object hotelId);
    }
}
