using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.Args;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.ViewModels;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.PageControls.Homepage
{
	[PresenterBinding(typeof(GetAllHotelsPresenter))]
	public partial class HomepageHotelsListControl : MvpUserControl<GetAllHotelsModel>, IGetAllHotelsView
	{
		public event EventHandler<GetAllHotelsArgs> GetAllHotels;

		protected void Page_Load(object sender, EventArgs e)
		{
			ListViewHotels_GetData();
		}
		
		public IList<Hotel> ListViewHotels_GetData()
		{
			this.GetAllHotels?.Invoke(this, new GetAllHotelsArgs());

			return this.Model.Hotels.ToList();
		}

		protected void Hotels_ItemCreated(object sender, ListViewItemEventArgs e)
		{
			var hyperlink = e.Item.FindControl("boardingRequest") as HyperLink;

			if (!this.Page.User.IsInRole("User") || !this.Page.User.Identity.IsAuthenticated)
			{
				hyperlink.Visible = false;
			}
		}
	}
}