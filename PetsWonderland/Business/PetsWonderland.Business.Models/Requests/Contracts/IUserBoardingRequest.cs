using System;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Requests.Contracts
{
    public interface IUserBoardingRequest
    {
        int Id { get; set; }

        DateTime DateOfRequest { get; set; }

        string UserId { get; set; }

        RegularUser User { get; set; }

        int? HotelId { get; set; }

        Hotel Hotel { get; set; }

        int? UserAnimalId { get; set; }

        UserAnimal UserAnimal { get; set; }

        bool IsAccepted { get; set; }

        bool IsDeleted { get; set; }
    }
}