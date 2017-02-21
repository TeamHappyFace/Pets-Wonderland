using PetsWonderland.Business.MVP.Hotels.GetAllHotels.Args;

namespace PetsWonderland.Business.MVP.Hotels.GetAllHotels.Contracts
{
    public interface IGetAllHotelsPresenter
    {
        void GetAllHotels(object sender, GetAllHotelsArgs e);
    }
}
