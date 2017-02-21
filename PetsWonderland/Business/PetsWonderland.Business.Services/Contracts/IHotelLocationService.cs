using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Business.Services.Contracts
{
    public interface IHotelLocationService
    {
        HotelLocation GetById(int id);

        HotelLocation GetByAddress(string address);

        void AddHotelLocation(HotelLocation locationToAdd);
    }
}
