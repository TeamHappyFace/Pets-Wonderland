using System.Collections.Generic;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Args;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Contracts;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest
{
    public class AddBoardingRequestPresenter : Presenter<IAddBoardingRequestView>, IAddBoardingRequestPresenter
    {
        private readonly IBoardingRequestService boardingRequestService;

        public AddBoardingRequestPresenter(
            IAddBoardingRequestView view,
            IBoardingRequestService boardingRequestService)
            : base(view)
        {
            Guard.WhenArgument(boardingRequestService, "boardingRequestService").IsNull().Throw();

            this.boardingRequestService = boardingRequestService;

            this.View.AddBoardingRequest += this.AddBoardingRequest;
            this.View.Model.BoardingRequests = new List<UserBoardingRequest>();
        }

        public void AddBoardingRequest(object sender, AddBoardingRequestArgs e)
        {
            this.boardingRequestService.AddBoardingRequest(e.BoardingRequestToAdd);

            this.View.Model.BoardingRequestToAdd = this.boardingRequestService.GetById(e.BoardingRequestToAdd.Id);
            this.View.Model.BoardingRequests.Add(e.BoardingRequestToAdd);
        }
    }
}
