using System;
using System.Web.UI.WebControls;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.MVP.Hotels.AddHotel;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Args;
using PetsWonderland.Business.MVP.Hotels.AddHotel.ViewModels;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Admin.Controls
{
	[PresenterBinding(typeof(AddHotelPresenter))]
	public partial class ApproveHotelRequest : MvpUserControl<AddHotelModel>, IAddHotelView
	{
		public event EventHandler<AddHotelArgs> AddHotel;
		private Hotel newHotel;

		public string HotelName { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			newHotel = new Hotel()
			{
				Name = this.HotelName,
				Description = this.Description,
				ImageUrl = this.ImageUrl
			};
		}

		protected void OnApprove_Click(object sender, EventArgs e)
		{
			var hotelArgs = new AddHotelArgs(newHotel);
			this.AddHotel?.Invoke(this, hotelArgs);

			//IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
		}
	}
}