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
            var newHotel = new Hotel()
            {
                Name = e.HotelName,
                Description = e.HotelDescription,
                HotelManagerId = e.HotelManagerId,
                ImageUrl = e.ImageUrl,
                IsDeleted = false
            };
            var hotelLocation = this.hotelLocationService.GetByAddress(e.Location);

            if (hotelLocation != null)
            {
                newHotel.Location = hotelLocation;
            }
            else
            {
                this.hotelLocationService.AddHotelLocation(new HotelLocation() { Address = e.Location });
                newHotel.Location = this.hotelLocationService.GetByAddress(e.Location);
            }

            this.hotelService.AddHotel(newHotel);

            this.View.Model.HotelToAdd = newHotel;
            this.View.Model.Hotels.Add(newHotel);

            this.hotelRegistrationRequestService.UpdateAccepted(e.RequestId, true);
        }
    }
}
