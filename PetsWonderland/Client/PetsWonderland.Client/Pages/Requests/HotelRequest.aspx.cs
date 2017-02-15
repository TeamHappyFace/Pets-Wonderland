using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Args;
using PetsWonderland.Business.Services;
using WebFormsMvp;

namespace PetsWonderland.Client.Pages.Requests
{
	[PresenterBinding(typeof(HotelRegistrationRequestService))]
	public partial class HotelRequest : Page
	{
		event EventHandler<AddHotelRequestArgs> EventAddHotelRegistrationRequest;

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public void CreateUserRequest_Click(object sender, EventArgs e)
		{
			var currentHotelManager = this.User.Identity.Name;

			var currentLocation = new HotelLocation()
			{
				Address = this.Location.ToString()
			};

			var currentHotel = new Hotel()
			{
				Name = this.HotelName.ToString(),
				Location = currentLocation,
				Description = this.Description.ToString()
			};

			var newHotelRegistrationRequest = new UserHotelRegistrationRequest()
			{
				Hotel = currentHotel,
				DateOfRequest = DateTime.Now,
				IsAccepted = false
			};

			var hotelRegistrationRequestArgs = new AddHotelRequestArgs(newHotelRegistrationRequest);
			this.EventAddHotelRegistrationRequest.Invoke(sender, hotelRegistrationRequestArgs);

			UploadImage();
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