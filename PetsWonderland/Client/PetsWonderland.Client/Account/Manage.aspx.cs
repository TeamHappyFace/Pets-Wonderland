using System;
using System.Web.UI;

namespace PetsWonderland.Client.Account
{
    public partial class Manage : Page
    {
        protected void Page_Load()
        {
			if (this.Page.User.IsInRole("Hotel manager"))
			{
				RequestsButton.Visible = true;
			}
        }

        protected void ImageButton_Click(object sender, EventArgs e)
        {
            this.MultiView.ActiveViewIndex = 0;
        }

        protected void PasswordButton_Click(object sender, EventArgs e)
        {
            this.MultiView.ActiveViewIndex = 1;
        }

		protected void RequestsButton_Click(object sender, EventArgs e)
		{
			this.MultiView.ActiveViewIndex = 2;
		}
	}
}