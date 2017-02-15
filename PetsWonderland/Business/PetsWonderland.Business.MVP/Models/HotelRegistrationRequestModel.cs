using System;
using System.Collections.Generic;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.MVP.Models
{
	public class HotelRegistrationRequestModel
	{
		public UserHotelRegistrationRequest HotelRequestToAdd { get; set; }

		public IList<UserHotelRegistrationRequest> HotelRegistrationRequests { get; set; }
	}
}
