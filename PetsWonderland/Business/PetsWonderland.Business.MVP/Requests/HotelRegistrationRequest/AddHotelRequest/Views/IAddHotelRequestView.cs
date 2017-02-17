using System;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Views
{
	public interface IAddHotelRequestView : IView<AddHotelRequestModel>
	{
		event EventHandler<AddHotelRequestArgs> AddHotelRegistrationRequest;
	}
}
