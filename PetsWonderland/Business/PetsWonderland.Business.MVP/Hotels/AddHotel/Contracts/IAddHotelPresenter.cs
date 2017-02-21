using PetsWonderland.Business.MVP.Hotels.AddHotel.Args;

namespace PetsWonderland.Business.MVP.Hotels.AddHotel.Contracts
{
    public interface IAddHotelPresenter
    {
        void AddHotel(object sender, AddHotelArgs e);
    }
}
