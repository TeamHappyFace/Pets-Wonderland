using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Args;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Contracts
{
    public interface IDeleteHotelRequestPresenter
    {
        void DeleteHotelRegistrationRequest(object sender, DeleteHotelRequestArgs e);
    }
}
