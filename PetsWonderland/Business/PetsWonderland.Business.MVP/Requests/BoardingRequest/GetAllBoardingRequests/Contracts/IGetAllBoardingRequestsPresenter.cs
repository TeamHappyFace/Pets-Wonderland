using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Args;

namespace PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Contracts
{
	public interface IGetAllBoardingRequestsPresenter
	{
		void GetAllBoardingRequests(object sender, GetAllBoardingRequestsArgs e);
	}
}
