using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Args;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Contracts
{
    public interface IAddHotelRequestPresenter
    {
        void AddHotelRegistrationRequest(object sender, AddHotelRequestArgs e);
    }
}
