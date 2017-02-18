using System.Collections.Generic;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.ViewModels
{
	public class GetAllBoardingRequestsModel
	{
		public List<UserBoardingRequest> BoardingRequests { get; set; }
	}
}
