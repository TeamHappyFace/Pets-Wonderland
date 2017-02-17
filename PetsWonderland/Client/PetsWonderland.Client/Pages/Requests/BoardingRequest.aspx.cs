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

				var newBoardingRequest = new UserBoardingRequest()
				{
					PetName = this.PetName.Text,
					Age = int.Parse(this.Age.Text),
					DateOfRequest = DateTime.Now,
					PetBreed = this.Breed.Text,
					UserId = currentUserId			 
				};

				var boardingRequestArgs = new AddBoardingRequestArgs(newBoardingRequest);
				this.AddBoardingRequest?.Invoke(this, boardingRequestArgs);

				UploadImage();
				IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
			}
		}

		private void UploadImage()
		{
			if (Image.HasFile)
				try
				{
					Image.SaveAs(Server.MapPath("~/Images/") + Image.FileName);
				}
				catch (Exception ex)
				{
					FileUploadedLabel.Text = "ERROR: " + ex.Message.ToString();
				}
			else
			{
				FileUploadedLabel.Text = "You have not specified a file.";
			}
		}
	}
}