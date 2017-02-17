using System;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Views
{
	public interface IGetAllHotelRequestView : IView<GetAllHotelRequestModel>
	{
		event EventHandler<GetAllHotelRequestsArgs> GetAllHotelRequests;
	}
}
