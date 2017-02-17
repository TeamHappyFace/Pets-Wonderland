using System;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Views
{
	public interface IDeleteHotelRequestView : IView<DeleteHotelRequestModel>
	{
		event EventHandler<DeleteHotelRequestArgs> DeleteHotelRegistrationRequest;
	}
}
