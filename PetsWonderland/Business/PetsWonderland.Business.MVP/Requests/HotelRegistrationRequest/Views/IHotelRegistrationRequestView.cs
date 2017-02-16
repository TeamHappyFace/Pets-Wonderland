using System;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.Views
{
	public interface IHotelRegistrationRequestView : IView<HotelRegistrationRequestModel>
	{
		event EventHandler<AddHotelRequestArgs> AddHotelRegistrationRequest;

		event EventHandler<DeleteHotelRequestArgs> DeleteHotelRegistrationRequest;

		event EventHandler<GetAllHotelRequestsArgs> GetAllHotelRequests;
	}
}
