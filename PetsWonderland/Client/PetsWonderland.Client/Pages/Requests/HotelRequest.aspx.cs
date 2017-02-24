using System;
using Microsoft.AspNet.Identity;
using PetsWonderland.Business.Identity;
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

                var hotelRegistrationRequestArgs = new AddHotelRequestArgs()
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
					hotelRegistrationRequestArgs.ImageUrl = (this.Server.MapPath("~/Images/") + this.Image.FileName);
				}
				else
				{
					hotelRegistrationRequestArgs.ImageUrl = this.ImageUrl.Text;
				}

                this.AddHotelRegistrationRequest?.Invoke(this, hotelRegistrationRequestArgs);
				
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], this.Response);
            }
        }  
    }
}