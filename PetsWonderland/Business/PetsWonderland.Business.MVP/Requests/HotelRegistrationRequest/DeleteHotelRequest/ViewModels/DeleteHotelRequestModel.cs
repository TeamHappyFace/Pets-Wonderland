using System.Collections.Generic;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.ViewModels
{
	public class DeleteHotelRequestModel
	{
		public UserHotelRegistrationRequest HotelRequestToAdd { get; set; }

		public IList<UserHotelRegistrationRequest> HotelRegistrationRequests { get; set; }
	}
}
