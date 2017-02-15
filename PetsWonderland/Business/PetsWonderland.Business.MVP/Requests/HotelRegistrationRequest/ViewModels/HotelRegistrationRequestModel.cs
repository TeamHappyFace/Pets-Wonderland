using System.Collections.Generic;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.ViewModels
{
	public class HotelRegistrationRequestModel
	{
		public UserHotelRegistrationRequest HotelRequestToAdd { get; set; }

		public IList<UserHotelRegistrationRequest> HotelRegistrationRequests { get; set; }
	}
}
