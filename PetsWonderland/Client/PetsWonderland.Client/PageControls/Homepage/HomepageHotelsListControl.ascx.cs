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

		protected void Page_Load(object sender, ListViewItemEventArgs e)
		{
			if (this.Page.User.IsInRole("User"))
			{
				HyperLink hyperlink = new HyperLink();

				hyperlink = (HyperLink)e.Item.FindControl("boardingRequest");
				hyperlink.Visible = true;
			}

			ListViewHotels_GetData();
		}

		public IList<Hotel> ListViewHotels_GetData()
		{
			this.GetAllHotels?.Invoke(this, new GetAllHotelsArgs());

			return this.Model.Hotels.ToList();
		}
	}
}