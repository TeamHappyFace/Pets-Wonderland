using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Hotels.Contracts
{
    public interface IUserHotel
    {
        int Id { get; set; }

        string HotelManagerId { get; set; }

        HotelManager HotelManager { get; set; }

        int? HotelId { get; set; }

        Hotel Hotel { get; set; }

        bool IsDeleted { get; set; }
    }
}