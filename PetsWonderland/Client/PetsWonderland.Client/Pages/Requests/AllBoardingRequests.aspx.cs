using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Args;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.ViewModels;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Pages.Requests
{
    [PresenterBinding(typeof(GetAllBoardingRequestsPresenter))]
    public partial class AllBoardingRequests : MvpPage<GetAllBoardingRequestsModel>, IGetAllBoardingRequestsView
    {
        public event EventHandler<GetAllBoardingRequestsArgs> GetAllBoardingRequests;

        public IQueryable<UserBoardingRequest> ListViewRequests_GetData()
        {
            this.GetAllBoardingRequests?.Invoke(this, new GetAllBoardingRequestsArgs());
            return this.Model.BoardingRequests
                .Where(req => req.IsDeleted == false)
                .Where(req => req.HotelManagerId == this.User.Identity.GetUserId())
                .AsQueryable();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewRequests_GetData();
        }        
    }
}