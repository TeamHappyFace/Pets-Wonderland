using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Admin.Controls
{
	[PresenterBinding(typeof(GetAllHotelRequestPresenter))]
	public partial class AllHotelRequests : MvpUserControl<GetAllHotelRequestModel>, IGetAllHotelRequestView
	{
		public event EventHandler<GetAllHotelRequestsArgs> GetAllHotelRequests;

		protected void Page_Load(object sender, EventArgs e)
		{
			ListViewHotelRequests_GetData();
		}

		public IList<UserHotelRegistrationRequest> ListViewHotelRequests_GetData()
		{
			this.GetAllHotelRequests?.Invoke(this, new GetAllHotelRequestsArgs());

			return this.Model.HotelRegistrationRequests.Where(req=>req.IsDeleted==false).ToList();
		}

		protected void OnDeny_Click(object sender, EventArgs e)
		{
			var argument = ((Button)sender).CommandArgument;
			int requestToDenyId = int.Parse(argument);
			
			var request = this.Model.HotelRegistrationRequests.FirstOrDefault(req => req.Id == requestToDenyId);
			request.IsDeleted = true;
			this.Model.HotelRegistrationRequests.Remove(request);			
		}
	}
}