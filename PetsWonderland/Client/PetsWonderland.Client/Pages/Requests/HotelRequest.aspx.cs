using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using PetsWonderland.Business.Identity;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Pages.Requests
{
	[PresenterBinding(typeof(HotelRegistrationRequestPresenter))]
	public partial class HotelRequest : MvpPage<HotelRegistrationRequestModel>, IHotelRegistrationRequestView
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
					HotelManagerId=currentHotelManagerId,
					Description = this.Description.Text, 
					DateOfRequest = DateTime.Now,
					IsAccepted = false
				};

				var hotelRegistrationRequestArgs = new AddHotelRequestArgs(newHotelRegistrationRequest);
				this.AddHotelRegistrationRequest(this, hotelRegistrationRequestArgs);

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