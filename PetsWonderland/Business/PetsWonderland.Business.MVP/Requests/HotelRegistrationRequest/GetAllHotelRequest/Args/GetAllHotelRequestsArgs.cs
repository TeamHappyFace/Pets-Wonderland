using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Args
{
	public class GetAllHotelRequestsArgs : EventArgs
	{
		public GetAllHotelRequestsArgs()
		{

		}

		public GetAllHotelRequestsArgs(IList<UserHotelRegistrationRequest> allHotelRequests)
		{
			Guard.WhenArgument(allHotelRequests, "All hotel request list is null!").IsNullOrEmpty().Throw();

			this.HotelRequests = allHotelRequests;
		}

		public IList<UserHotelRegistrationRequest> HotelRequests { get; set; }
	}
}
