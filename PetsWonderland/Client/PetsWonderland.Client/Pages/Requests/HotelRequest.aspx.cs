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

        public void CreateUserRequest_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var currentHotelManagerId = User.Identity.GetUserId();

                var newHotelRegistrationRequest = new UserHotelRegistrationRequest()
                {
                    HotelName = this.HotelName.Text,
                    HotelLocation = this.Location.Text,
                    HotelImageUrl = this.ImageUrl.Text,
                    HotelManagerId = currentHotelManagerId,
                    HotelDescription = this.Description.Text,
                    DateOfRequest = DateTime.Now,
                    IsAccepted = false
                };

                var hotelRegistrationRequestArgs = new AddHotelRequestArgs(newHotelRegistrationRequest);
                this.AddHotelRegistrationRequest?.Invoke(this, hotelRegistrationRequestArgs);

                this.UploadImage();
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], this.Response);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }        

        private void UploadImage()
        {
            if (this.Image.HasFile)
            {
                try
                {
                    this.Image.SaveAs(Server.MapPath("~/Images/") + this.Image.FileName);
                }
                catch (Exception ex)
                {
                    this.FileUploadedLabel.Text = "ERROR: " + ex.Message.ToString();
                }
            }                
            else
            {
                this.FileUploadedLabel.Text = "You have not specified a file.";
            }
        }
    }
}