using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Args;

namespace PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Contracts
{
    public interface IAddBoardingRequestPresenter
    {
        void AddBoardingRequest(object sender, AddBoardingRequestArgs e);
    }
}
