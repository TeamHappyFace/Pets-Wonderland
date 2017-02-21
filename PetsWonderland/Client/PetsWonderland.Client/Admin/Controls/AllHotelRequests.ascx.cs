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

        public IQueryable<UserHotelRegistrationRequest> ListViewHotelRequests_GetData()
        {
            this.GetAllHotelRequests?.Invoke(this, new GetAllHotelRequestsArgs());

            return this.Model.HotelRegistrationRequests.Where(req => req.IsDeleted == false).AsQueryable();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ListViewHotelRequests_GetData();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (this.Session["id"] == null)
            {
                this.Session["id"] = string.Empty;
            }

            if (this.Session["name"] == null)
            {
                this.Session["name"] = string.Empty;
            }

            if (this.Session["location"] == null)
            {
                this.Session["location"] = string.Empty;
            }

            if (this.Session["description"] == null)
            {
                this.Session["description"] = string.Empty;
            }

            if (this.Session["image"] == null)
            {
                this.Session["image"] = string.Empty;
            }

            if (this.Session["hotelManagerId"] == null)
            {
                this.Session["hotelManagerId"] = string.Empty;
            }
        }        

        protected void HotelRequests_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            var id = e.Item.FindControl("hidden") as HiddenField;
            var hotelManagerId = e.Item.FindControl("hotelManagerId") as HiddenField;
            var name = e.Item.FindControl("hotelName") as Label;
            var location = e.Item.FindControl("location") as Label;
            var image = e.Item.FindControl("image") as Image;
            var description = e.Item.FindControl("description") as Panel;

            this.Session["id"] = id.Value;
            this.Session["hotelManagerId"] = hotelManagerId.Value;
            this.Session["name"] = name.Text;
            this.Session["location"] = location.Text;
            this.Session["description"] = description.Attributes["Text"];
            this.Session["image"] = image.ImageUrl;

            Response.Redirect("ApproveHotelRequest.aspx");
        }
    }
}