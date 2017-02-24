using System.Collections.Generic;
using System.Linq;
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
        private readonly IHotelLocationService hotelLocationService;
        private readonly IHotelRegistrationRequestService hotelRegistrationRequestService;

        public AddHotelPresenter(
            IAddHotelView view,
            IHotelService hotelService, 
            IHotelLocationService hotelLocationService,
            IHotelRegistrationRequestService hotelRegistrationRequestService)
            : base(view)
        {
            Guard.WhenArgument(hotelService, "hotelService").IsNull().Throw();
            Guard.WhenArgument(hotelLocationService, "hotelLocationService").IsNull().Throw();
			Guard.WhenArgument(hotelRegistrationRequestService, "hotelRegistrationRequestService").IsNull().Throw();

            this.hotelService = hotelService;
            this.hotelLocationService = hotelLocationService;
            this.hotelRegistrationRequestService = hotelRegistrationRequestService;

            this.View.AddHotel += this.AddHotel;
            this.View.Model.Hotels = new List<Hotel>();
        }

        public void AddHotel(object sender, AddHotelArgs e)
        {
            var hotelLocation = this.hotelLocationService.GetByAddress(e.Location);

            if (hotelLocation == null)
            {
                hotelLocation = this.hotelLocationService.AddHotelLocation(e.Location);
			}

			this.hotelService.AddHotel(e.HotelName, e.HotelDescription, e.HotelManagerId,
					hotelLocation, e.ImageUrl);

			this.View.Model.Hotels = this.hotelService.GetAllHotels().ToList();

            this.hotelRegistrationRequestService.UpdateAccepted(e.RequestId, true);
        }
    }
}
