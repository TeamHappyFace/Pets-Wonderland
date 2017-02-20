using System;
using PetsWonderland.Business.MVP.Hotels.AddHotel;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Args;
using PetsWonderland.Business.MVP.Hotels.AddHotel.ViewModels;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Admin
{
	[PresenterBinding(typeof(AddHotelPresenter))]
	public partial class ApproveHotelRequest : MvpPage<AddHotelModel>, IAddHotelView
	{
		public event EventHandler<AddHotelArgs> AddHotel;

		protected void Page_Load(object sender, EventArgs e)
		{
			Approve();
		}

		protected void Approve()
		{
			var requestId = (string)(Session["id"]);
			var hotelName = (string)(Session["name"]);
			var hotelDescription = (string)(Session["description"]);
			var hotelImage = (string)(Session["image"]);
			var hotelLocation = (string)(Session["location"]);

			var hotelArgs = new AddHotelArgs
			{
				HotelName = (hotelName != null ? hotelName : ""),
				HotelDescription = (hotelDescription!= null ? hotelDescription : ""),
				ImageUrl = (hotelImage != null ? hotelImage : ""),
				Location = (hotelLocation != null ? hotelLocation : ""),
				RequestId = int.Parse(requestId)
			};

			this.AddHotel?.Invoke(this, hotelArgs);
		}
	}
}