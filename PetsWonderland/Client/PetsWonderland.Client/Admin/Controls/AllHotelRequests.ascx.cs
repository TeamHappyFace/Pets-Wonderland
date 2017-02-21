using System;
using System.Linq;
using System.Web.UI.WebControls;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Admin.Controls
{
	[PresenterBinding(typeof(GetAllHotelRequestPresenter))]
	public partial class AllHotelRequests : MvpUserControl<GetAllHotelRequestModel>, IGetAllHotelRequestView
	{
		public event EventHandler<GetAllHotelRequestsArgs> GetAllHotelRequests;

		protected void Page_Load(object sender, EventArgs e)
		{
		    if (!IsPostBack)
		    {
                ListViewHotelRequests_GetData();
            }			
		}

		protected override void OnPreRender(EventArgs e)
		{
			if (Session["id"] == null)
			{
				Session["id"] = "";
			}

			if (Session["name"] == null)
			{
				Session["name"] = "";
			}

			if (Session["location"] == null)
			{
				Session["location"] = "";
			}

			if (Session["description"] == null)
			{
				Session["description"] = "";
			}

			if (Session["image"] == null)
			{
				Session["image"] = "";
			}

			if(Session["hotelManagerId"] == null)
			{
				Session["hotelManagerId"] = "";
			}
		}

		public IQueryable<UserHotelRegistrationRequest> ListViewHotelRequests_GetData()
		{
			this.GetAllHotelRequests?.Invoke(this, new GetAllHotelRequestsArgs());

			return this.Model.HotelRegistrationRequests.Where(req=>req.IsDeleted==false).AsQueryable();
		}

		protected void HotelRequests_ItemCommand(object sender, ListViewCommandEventArgs e)
		{
			var id = e.Item.FindControl("hidden") as HiddenField;
			var hotelManagerId = e.Item.FindControl("hotelManagerId") as HiddenField;
			var name = e.Item.FindControl("hotelName") as Label;
			var location = e.Item.FindControl("location") as Label;
			var image = e.Item.FindControl("image") as Image;
			var description = e.Item.FindControl("description") as TextBox;

			Session["id"] = id.Value;
			Session["hotelManagerId"] = hotelManagerId.Value;
			Session["name"] = name.Text;
			Session["location"] = location.Text;
			Session["description"] = description.Text;
			Session["image"] = image.ImageUrl;
			
			Response.Redirect("ApproveHotelRequest.aspx");
		}

		protected void HotelRequests_ItemCreated(object sender, ListViewItemEventArgs e)
		{
			var image = e.Item.FindControl("image") as Image;

			if (image.ImageUrl == "")
			{
				image.Visible = false;
			}
		}
	}
}