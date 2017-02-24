using System;
using System.Linq;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.Services.Contracts
{
    public interface IHotelRegistrationRequestService
    {
        IQueryable<UserHotelRegistrationRequest> GetAllHotelRequests();

        UserHotelRegistrationRequest GetById(int id);

        void AddHotelRequest(string hotelName, string hotelLocation, string hotelManagerId,
				string hotelDescription, DateTime dateOfRequest, string ImageUrl, bool isAccepted);

        void UpdateAccepted(int userHotelRegistrationRequestId, bool isAccepted);

        void UpdateDeleted(int requestId, bool isDeleted);
    }
}
