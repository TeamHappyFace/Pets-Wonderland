using System;
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

		public int RequestId
		{
			get
			{
				if (ViewState["RequestId"] == null)
				{
					return 0;
				}
				else
				{
					return (int)ViewState["RequestId"];
				}
			}
			set
			{
				ViewState["RequestId"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void OnDeny_Click(object sender, EventArgs e)
		{
			this.DeleteHotelRegistrationRequest?.Invoke(this, new DeleteHotelRequestArgs(this.RequestId));
		}
	}
}