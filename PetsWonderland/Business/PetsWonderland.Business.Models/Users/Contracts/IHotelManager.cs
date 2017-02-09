using System.Collections.Generic;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.Models.Users.Contracts
{
    public interface IHotelManager
    {
        ICollection<Hotel> Hotels { get; set; }

        ICollection<UserBoardingRequest> UserBoardingRequests { get; set; }

        bool IsDeleted { get; set; }
    }
}