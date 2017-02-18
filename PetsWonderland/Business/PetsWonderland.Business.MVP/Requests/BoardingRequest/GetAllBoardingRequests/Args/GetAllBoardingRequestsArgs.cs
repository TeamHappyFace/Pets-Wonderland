using System;
using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Args
{
	public class GetAllBoardingRequestsArgs : EventArgs
	{
		public GetAllBoardingRequestsArgs()
		{

		}

		public GetAllBoardingRequestsArgs(IQueryable<UserBoardingRequest> allBoardingRequests)
		{
			Guard.WhenArgument(allBoardingRequests, "All hotel request list is null!").IsNullOrEmpty().Throw();

			this.BoardingRequests = allBoardingRequests;
		}

		public IQueryable<UserBoardingRequest> BoardingRequests { get; set; }
	}
}
