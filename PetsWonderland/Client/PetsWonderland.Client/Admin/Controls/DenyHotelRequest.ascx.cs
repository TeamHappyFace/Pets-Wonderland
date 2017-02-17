using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Admin.Controls
{
	[PresenterBinding(typeof(DeleteHotelRequestPresenter))]
	public partial class DenyHotelRequest : MvpUserControl<DeleteHotelRequestModel>, IDeleteHotelRequestView
	{
		public event EventHandler<DeleteHotelRequestArgs> DeleteHotelRegistrationRequest;

		public int RequestId { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void OnDeny_Click(object sender, EventArgs e)
		{
			this.DeleteHotelRegistrationRequest?.Invoke(this, new DeleteHotelRequestArgs(RequestId));
		}
	}
}