using System;
using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Args
{
	public class GetAllHotelRequestsArgs : EventArgs
	{
		public GetAllHotelRequestsArgs()
		{

		}

		public GetAllHotelRequestsArgs(IQueryable<UserHotelRegistrationRequest> allHotelRequests)
		{
			Guard.WhenArgument(allHotelRequests, "All hotel request list is null!").IsNullOrEmpty().Throw();

			this.HotelRequests = allHotelRequests;
		}

		public IQueryable<UserHotelRegistrationRequest> HotelRequests { get; set; }
	}
}
