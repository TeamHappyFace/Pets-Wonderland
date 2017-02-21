using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Args;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Contracts;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests
{
    public class GetAllBoardingRequestsPresenter : Presenter<IGetAllBoardingRequestsView>, IGetAllBoardingRequestsPresenter
    {
        private readonly IBoardingRequestService boardingRequestService;

        public GetAllBoardingRequestsPresenter(
            IGetAllBoardingRequestsView view,
            IBoardingRequestService boardingRequestService)
            : base(view)
        {
            Guard.WhenArgument(boardingRequestService, "boardingRequestService").IsNull().Throw();

            this.boardingRequestService = boardingRequestService;

            this.View.GetAllBoardingRequests += this.GetAllBoardingRequests;
            this.View.Model.BoardingRequests = new List<UserBoardingRequest>();
        }

        public void GetAllBoardingRequests(object sender, GetAllBoardingRequestsArgs e)
        {
            var allRequests = this.boardingRequestService.GetAllBoardingRequests().ToList();
            this.View.Model.BoardingRequests = allRequests;
        }
    }
}
