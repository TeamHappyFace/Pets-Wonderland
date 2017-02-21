using System;
using System.Web.UI;

namespace PetsWonderland.Client.Account
{
    public partial class Manage : Page
    {
        protected void Page_Load()
        {
        }

		protected void ImageButton_Click(object sender, EventArgs e)
		{
			this.MultiView.ActiveViewIndex = 0;
		}

		protected void PasswordButton_Click(object sender, EventArgs e)
		{
			this.MultiView.ActiveViewIndex = 1;
		}
	}
}