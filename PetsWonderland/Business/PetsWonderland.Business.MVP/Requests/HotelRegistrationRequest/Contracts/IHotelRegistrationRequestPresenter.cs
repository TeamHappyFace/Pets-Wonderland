using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.Args;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.Contracts
{
	public interface IHotelRegistrationRequestPresenter
	{
		void GetAllHotelRegistrationRequests(object sender, GetAllHotelRequestsArgs e);
		void AddHotelRegistrationRequest(object sender, AddHotelRequestArgs e);
	}
}
