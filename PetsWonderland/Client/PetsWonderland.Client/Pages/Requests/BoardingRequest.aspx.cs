using System;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using PetsWonderland.Business.Identity;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Args;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Pages.Requests
{
    [PresenterBinding(typeof(AddBoardingRequestPresenter))]
    public partial class BoardingRequest : MvpPage<AddBoardingRequestModel>, IAddBoardingRequestView
    {
        public event EventHandler<AddBoardingRequestArgs> AddBoardingRequest;
       
        public void CreateUserRequest_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                var hotelManagerId = Request.QueryString["id"];

                var newBoardingRequest = new UserBoardingRequest()
                {
                    PetName = this.PetName.Text,
                    Age = int.Parse(this.Age.Text),
                    ImageUrl = this.ImageUrl.Text,
                    DateOfRequest = DateTime.Now,
                    FromDate = this.txtFrom.Text,
                    ToDate = this.txtTo.Text,
                    PetBreed = this.Breed.Text,
                    UserId = currentUserId,
                    HotelManagerId = hotelManagerId
                };

                var boardingRequestArgs = new AddBoardingRequestArgs(newBoardingRequest);
                this.AddBoardingRequest?.Invoke(this, boardingRequestArgs);

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
                try
                {
                    this.Image.SaveAs(Server.MapPath("~/Images/") + this.Image.FileName);
                }
                catch (Exception ex)
                {
                    FileUploadedLabel.Text = "ERROR: " + ex.Message.ToString();
                }
            else
            {
                this.FileUploadedLabel.Text = "You have not specified a file.";
            }
        }
    }
}