using System;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Requests.Contracts
{
    public interface IUserHotelRegistrationRequest
    {
        int Id { get; set; }

        DateTime DateOfRequest { get; set; }

        string HotelName { get; set; }

        string HotelLocation { get; set; }

        string HotelDescription { get; set; }

        string HotelImageUrl { get; set; }

        string HotelManagerId { get; set; }

        HotelManager HotelManager { get; set; }

        bool IsAccepted { get; set; }

        bool IsDeleted { get; set; }
    }
}