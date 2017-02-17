using System;
using System.Linq;
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

		public IQueryable<UserHotelRegistrationRequest> ListViewHotelRequests_GetData()
		{
			this.GetAllHotelRequests?.Invoke(this, new GetAllHotelRequestsArgs());

			return this.Model.HotelRegistrationRequests.Where(req=>req.IsDeleted==false).AsQueryable();
		}
	}
}