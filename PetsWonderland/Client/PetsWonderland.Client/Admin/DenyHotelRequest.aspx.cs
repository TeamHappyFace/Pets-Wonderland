using System;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Admin
{
	[PresenterBinding(typeof(DeleteHotelRequestPresenter))]
	public partial class DenyHotelRequest : MvpPage<DeleteHotelRequestModel>, IDeleteHotelRequestView
	{
		public event EventHandler<DeleteHotelRequestArgs> DeleteHotelRegistrationRequest;

		protected void Page_Load(object sender, EventArgs e)
		{
			Deny();
		}

		protected void Deny()
		{
			int requestId = int.Parse(Request.QueryString["id"]);
			this.DeleteHotelRegistrationRequest?.Invoke(this, new DeleteHotelRequestArgs(requestId));
		}
	}
}