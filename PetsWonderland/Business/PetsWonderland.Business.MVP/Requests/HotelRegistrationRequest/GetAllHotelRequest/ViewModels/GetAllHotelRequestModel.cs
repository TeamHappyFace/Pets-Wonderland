﻿using System.Collections.Generic;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.ViewModels
{
	public class GetAllHotelRequestModel
	{
		public UserHotelRegistrationRequest HotelRequestToAdd { get; set; }

		public IList<UserHotelRegistrationRequest> HotelRegistrationRequests { get; set; }
	}
}