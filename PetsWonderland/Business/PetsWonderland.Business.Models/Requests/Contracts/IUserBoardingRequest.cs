using System;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Requests.Contracts
{
    public interface IUserBoardingRequest
    {
        int Id { get; set; }

        DateTime DateOfRequest { get; set; }

        string PetName { get; set; }

        string PetBreed { get; set; }

        int Age { get; set; }

        string FromDate { get; set; }

        string ToDate { get; set; }

        string UserId { get; set; }

        RegularUser User { get; set; }

        string HotelManagerId { get; set; }

        HotelManager HotelManager { get; set; }

        bool IsAccepted { get; set; }

        bool IsDeleted { get; set; }
    }
}