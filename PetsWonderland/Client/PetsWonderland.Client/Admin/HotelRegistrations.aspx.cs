using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Admin
{
	[PresenterBinding(typeof(HotelRegistrationRequestPresenter))]
	public partial class HotelRegistrations : MvpPage<HotelRegistrationRequestModel>, IHotelRegistrationRequestView
	{
		public event EventHandler<AddHotelRequestArgs> AddHotelRegistrationRequest;
		public event EventHandler<GetAllHotelRequestsArgs> GetAllHotelRequests;
		public event EventHandler<DeleteHotelRequestArgs> DeleteHotelRegistrationRequest;

		protected void Page_Load(object sender, EventArgs e)
		{
			ListViewHotelRequests_GetData();
		}

		public IList<UserHotelRegistrationRequest> ListViewHotelRequests_GetData()
		{
			this.GetAllHotelRequests?.Invoke(this, new GetAllHotelRequestsArgs());

			return this.Model.HotelRegistrationRequests;
		}

		protected void OnApprove_Click(object sender, ListViewCommandEventArgs e)
		{
			
		}

		protected void OnDeny_Click(object sender, ListViewCommandEventArgs e)
		{
			int requestToDeleteId = (int)e.CommandArgument;

			this.DeleteHotelRegistrationRequest?.Invoke(this, new DeleteHotelRequestArgs(requestToDeleteId));
		}
	}
}