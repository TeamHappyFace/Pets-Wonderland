using System.Collections.Generic;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Contracts;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest
{
	public class AddHotelRequestPresenter : Presenter<IAddHotelRequestView>, IAddHotelRequestPresenter
	{
		private readonly IHotelRegistrationRequestService hotelRegistrationRequestService;

		public AddHotelRequestPresenter(IAddHotelRequestView view,
			IHotelRegistrationRequestService hotelRegistrationRequestService)
			: base(view)
		{
			Guard.WhenArgument(hotelRegistrationRequestService, "hotelRegistrationRequestService").IsNull().Throw();

			this.hotelRegistrationRequestService = hotelRegistrationRequestService;

			this.View.AddHotelRegistrationRequest += AddHotelRegistrationRequest;
			this.View.Model.HotelRegistrationRequests = new List<UserHotelRegistrationRequest>();
		}

		public void AddHotelRegistrationRequest(object sender, AddHotelRequestArgs e)
		{
			this.hotelRegistrationRequestService.AddHotelRequest(e.HotelRequestToAdd);
			this.View.Model.HotelRequestToAdd = hotelRegistrationRequestService.GetById(e.HotelRequestToAdd.Id);
			this.View.Model.HotelRegistrationRequests.Add(e.HotelRequestToAdd);
		}
	}
}
