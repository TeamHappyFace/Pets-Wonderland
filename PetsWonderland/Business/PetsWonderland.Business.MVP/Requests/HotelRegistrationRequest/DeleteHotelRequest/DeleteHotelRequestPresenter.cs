using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Contracts;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest
{
	public class DeleteHotelRequestPresenter : Presenter<IDeleteHotelRequestView>, IDeleteHotelRequestPresenter
	{
		private readonly IHotelRegistrationRequestService hotelRegistrationRequestService;

		public DeleteHotelRequestPresenter(IDeleteHotelRequestView view,
			IHotelRegistrationRequestService hotelRegistrationRequestService)
			: base(view)
		{
			Guard.WhenArgument(hotelRegistrationRequestService, "hotelRegistrationRequestService").IsNull().Throw();

			this.hotelRegistrationRequestService = hotelRegistrationRequestService;
			
			this.View.DeleteHotelRegistrationRequest += DeleteHotelRegistrationRequest;
			this.View.Model.HotelRegistrationRequests = new List<UserHotelRegistrationRequest>();
		}

		public void DeleteHotelRegistrationRequest(object sender, DeleteHotelRequestArgs e)
		{
			this.hotelRegistrationRequestService.UpdateDeleted(e.HotelRequestToDeleteId, true);

			var request = this.View.Model.HotelRegistrationRequests.First(req => req.Id == e.HotelRequestToDeleteId);
			this.View.Model.HotelRegistrationRequests.Remove(request);
		}
	}
}
