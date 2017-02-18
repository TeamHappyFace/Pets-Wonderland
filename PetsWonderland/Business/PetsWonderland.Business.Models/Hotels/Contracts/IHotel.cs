using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Hotels.Contracts
{
    public interface IHotel
    {
        int Id { get; set; }

        string Name { get; set; }

        string ImageUrl { get; set; }

        string Description { get; set; }

        int? LocationId { get; set; }

        HotelLocation Location { get; set; }

		string HotelManagerId { get; set; }

		HotelManager HotelManager { get; set; }

		bool IsDeleted { get; set; }
    }
}