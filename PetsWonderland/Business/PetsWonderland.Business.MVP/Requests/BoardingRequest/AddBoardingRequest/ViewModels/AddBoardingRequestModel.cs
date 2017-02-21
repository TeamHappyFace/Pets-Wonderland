using System.Collections.Generic;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.ViewModels
{
    public class AddBoardingRequestModel
    {
        public UserBoardingRequest BoardingRequestToAdd { get; set; }

        public IList<UserBoardingRequest> BoardingRequests { get; set; }
    }
}
