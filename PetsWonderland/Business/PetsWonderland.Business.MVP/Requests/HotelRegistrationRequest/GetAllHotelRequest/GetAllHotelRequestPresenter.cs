using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Contracts;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest
{
	public class GetAllHotelRequestPresenter : Presenter<IGetAllHotelRequestView>, IGetAllHotelRequestPresenter
	{
		private readonly IHotelRegistrationRequestService hotelRegistrationRequestService;

		public GetAllHotelRequestPresenter(IGetAllHotelRequestView view,
			IHotelRegistrationRequestService hotelRegistrationRequestService)
			: base(view)
		{
			Guard.WhenArgument(hotelRegistrationRequestService, "hotelRegistrationRequestService").IsNull().Throw();

			this.hotelRegistrationRequestService = hotelRegistrationRequestService;
			
			this.View.GetAllHotelRequests += GetAllHotelRegistrationRequests;
			this.View.Model.HotelRegistrationRequests = new List<UserHotelRegistrationRequest>();
		}
		
		public void GetAllHotelRegistrationRequests(object sender, GetAllHotelRequestsArgs e)
		{
			var allRequests = this.hotelRegistrationRequestService.GetAllHotelRequests().ToList();
			this.View.Model.HotelRegistrationRequests = allRequests;
		}
	}
}
