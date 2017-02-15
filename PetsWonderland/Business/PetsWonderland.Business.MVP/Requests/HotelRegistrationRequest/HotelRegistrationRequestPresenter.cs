using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.Contracts;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest
{
	public class HotelRegistrationRequestPresenter : Presenter<IHotelRegistrationRequestView>, IHotelRegistrationRequestPresenter
	{
		private readonly IHotelRegistrationRequestService hotelRegistrationRequestService;

		public HotelRegistrationRequestPresenter(IHotelRegistrationRequestView view,
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

		public void GetAllHotelRegistrationRequests(object sender, GetAllHotelRequestsArgs e)
		{
			var allRequests = this.hotelRegistrationRequestService.GetAllHotelRequests().ToList();
			this.View.Model.HotelRegistrationRequests = allRequests;
		}
	}
}
