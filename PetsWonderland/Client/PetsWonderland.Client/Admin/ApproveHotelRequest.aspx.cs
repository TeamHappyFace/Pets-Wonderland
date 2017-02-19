using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
			var hotelArgs = new AddHotelArgs
			{
				//HotelName = this.HotelName,
				//HotelDescription = this.Description
			};
			this.AddHotel?.Invoke(this, hotelArgs);
		}
	}
}