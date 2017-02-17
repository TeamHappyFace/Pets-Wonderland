using System;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Args;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Views
{
	public interface IAddBoardingRequestView : IView<AddBoardingRequestModel>
	{
		event EventHandler<AddBoardingRequestArgs> AddBoardingRequest;
	}
}
