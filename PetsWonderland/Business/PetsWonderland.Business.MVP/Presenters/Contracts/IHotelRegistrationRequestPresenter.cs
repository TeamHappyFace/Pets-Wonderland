using PetsWonderland.Business.MVP.Args;

namespace PetsWonderland.Business.MVP.Presenters.Contracts
{
	public interface IHotelRegistrationRequestPresenter
	{
		void GetAllHotelRegistrationRequests(object sender, GetAllHotelRequestsArgs e);
		void AddHotelRegistrationRequest(object sender, AddHotelRequestArgs e);
	}
}
