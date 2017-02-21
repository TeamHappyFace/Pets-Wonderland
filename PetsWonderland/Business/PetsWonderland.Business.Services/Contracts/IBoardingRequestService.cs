using System.Linq;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.Services.Contracts
{
    public interface IBoardingRequestService
    {
        IQueryable<UserBoardingRequest> GetAllBoardingRequests();

        UserBoardingRequest GetById(int id);

        void AddBoardingRequest(UserBoardingRequest requestToAdd);

        void DeleteBoardingRequestById(object requestId);

        void DeleteBoardingRequest(UserBoardingRequest requestToDelete);
    }
}
