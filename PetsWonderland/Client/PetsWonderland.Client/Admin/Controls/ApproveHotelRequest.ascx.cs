using System;
using System.Web.UI.WebControls;

namespace PetsWonderland.Client.Admin.Controls
{
	public partial class ApproveHotelRequest : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void OnApprove_Click(object sender, EventArgs e)
		{
			var argument = ((Button)sender).CommandArgument;
		}
	}
}