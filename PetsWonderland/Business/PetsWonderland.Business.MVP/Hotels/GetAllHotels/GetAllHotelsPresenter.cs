using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.Args;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.Contracts;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Hotels.GetAllHotels
{
    public class GetAllHotelsPresenter : Presenter<IGetAllHotelsView>, IGetAllHotelsPresenter
    {
        private readonly IHotelService hotelService;

        public GetAllHotelsPresenter(
            IGetAllHotelsView view,
            IHotelService hotelService)
            : base(view)
        {
            Guard.WhenArgument(hotelService, "hotelService").IsNull().Throw();

            this.hotelService = hotelService;

            this.View.GetAllHotels += this.GetAllHotels;
            this.View.Model.Hotels = new List<Hotel>();
        }

        public void GetAllHotels(object sender, GetAllHotelsArgs e)
        {
            var allRequests = this.hotelService.GetHotels(e.StartAt, e.Count).ToList();
            this.View.Model.Hotels = allRequests;
        }
    }
}
