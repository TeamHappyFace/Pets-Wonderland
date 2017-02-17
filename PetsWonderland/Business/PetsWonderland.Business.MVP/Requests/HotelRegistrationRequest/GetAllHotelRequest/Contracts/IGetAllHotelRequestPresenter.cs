using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Args;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Contracts
{
	public interface IGetAllHotelRequestPresenter
	{
		void GetAllHotelRegistrationRequests(object sender, GetAllHotelRequestsArgs e);
	}
}
