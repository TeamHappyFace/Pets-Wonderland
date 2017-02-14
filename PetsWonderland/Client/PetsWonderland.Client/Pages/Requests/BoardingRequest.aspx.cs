using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetsWonderland.Client.Pages.Requests
{
	public partial class BoardingRequest : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public void CreateUserRequest_Click(object sender, EventArgs e)
		{
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