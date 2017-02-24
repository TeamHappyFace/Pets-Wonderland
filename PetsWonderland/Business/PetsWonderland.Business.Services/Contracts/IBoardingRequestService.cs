using System;
using System.Linq;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.Services.Contracts
{
    public interface IBoardingRequestService
    {
        IQueryable<UserBoardingRequest> GetAllBoardingRequests();

        UserBoardingRequest GetById(int id);

        void AddBoardingRequest(string petName, int age, DateTime dateOfRequest, string fromDate, string toDate,
						string petBreed, string imageUrl, string userId, string hotelManagerId);
    }
}
