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

		protected void Page_Load(object sender, EventArgs e)
		{
		}

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
                    DateOfRequest = DateTime.Now,
                    FromDate = this.txtFrom.Text,
                    ToDate = this.txtTo.Text,
                    PetBreed = this.Breed.Text,
                    UserId = currentUserId,
                    HotelManagerId = hotelManagerId
                };

				if (this.Image.HasFile)
				{
					this.Image.SaveAs(Server.MapPath("~/Images/") + this.Image.FileName);
					newBoardingRequest.ImageUrl = (this.Server.MapPath("~/Images/") + this.Image.FileName); 
				}
				else
				{
					newBoardingRequest.ImageUrl = this.ImageUrl.Text;
				}

				var boardingRequestArgs = new AddBoardingRequestArgs(newBoardingRequest);
                this.AddBoardingRequest?.Invoke(this, boardingRequestArgs);
				
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], this.Response);
            }
        }
    }
}