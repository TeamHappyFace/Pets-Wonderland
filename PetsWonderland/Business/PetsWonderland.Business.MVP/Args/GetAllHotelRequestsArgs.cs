using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.MVP.Args
{
	public class GetAllHotelRequestsArgs : EventArgs
	{
		public GetAllHotelRequestsArgs(IList<UserHotelRegistrationRequest> allHotelRequests)
		{
			Guard.WhenArgument(allHotelRequests, "All animals list is null!").IsNullOrEmpty().Throw();

			this.HotelRequests = allHotelRequests;
		}

		public IList<UserHotelRegistrationRequest> HotelRequests { get; set; }
	}
}
