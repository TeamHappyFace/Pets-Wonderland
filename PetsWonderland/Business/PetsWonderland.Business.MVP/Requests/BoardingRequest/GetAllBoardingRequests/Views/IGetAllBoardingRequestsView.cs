using System;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Args;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Views
{
	public interface IGetAllBoardingRequestsView : IView<GetAllBoardingRequestsModel>
	{
		event EventHandler<GetAllBoardingRequestsArgs> GetAllBoardingRequests;
	}
}
