using System.Collections.Generic;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Args;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Contracts;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Hotels.AddHotel
{
	public class AddHotelPresenter : Presenter<IAddHotelView>, IAddHotelPresenter
	{
		private readonly IHotelService hotelService;

		public AddHotelPresenter(IAddHotelView view,
			IHotelService hotelService)
			: base(view)
		{
			Guard.WhenArgument(hotelService, "hotelRegistrationRequestService").IsNull().Throw();

			this.hotelService = hotelService;

			this.View.AddHotel += AddHotel;
			this.View.Model.Hotels = new List<Hotel>();
		}

		public void AddHotel(object sender, AddHotelArgs e)
		{
			/*this.hotelService.AddHotel(e.HotelToAdd);
			this.View.Model.HotelToAdd = hotelService.GetById(e.HotelToAdd.Id);
			this.View.Model.Hotels.Add(e.HotelToAdd);*/
		}
	}
}
