using System;
using Microsoft.AspNet.Identity;
using PetsWonderland.Business.Identity;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Pages.Requests
{
    [PresenterBinding(typeof(AddHotelRequestPresenter))]
    public partial class HotelRequest : MvpPage<AddHotelRequestModel>, IAddHotelRequestView
    {
        public event EventHandler<AddHotelRequestArgs> AddHotelRegistrationRequest;

		protected void Page_Load(object sender, EventArgs e)
		{
		}

		public void CreateUserRequest_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var currentHotelManagerId = User.Identity.GetUserId();

                var newHotelRegistrationRequest = new UserHotelRegistrationRequest()
                {
                    HotelName = this.HotelName.Text,
                    HotelLocation = this.Location.Text,
                    HotelManagerId = currentHotelManagerId,
                    HotelDescription = this.Description.Text,
                    DateOfRequest = DateTime.Now,
                    IsAccepted = false
                };

				if (this.Image.HasFile)
				{
					this.Image.SaveAs(Server.MapPath("~/Images/") + this.Image.FileName);
					newHotelRegistrationRequest.HotelImageUrl = (this.Server.MapPath("~/Images/") + this.Image.FileName);
				}
				else
				{
					newHotelRegistrationRequest.HotelImageUrl = this.ImageUrl.Text;
				}

				var hotelRegistrationRequestArgs = new AddHotelRequestArgs(newHotelRegistrationRequest);
                this.AddHotelRegistrationRequest?.Invoke(this, hotelRegistrationRequestArgs);
				
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], this.Response);
            }
        }  
    }
}