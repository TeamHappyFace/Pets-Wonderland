using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Business.Models.Animals.Contracts
{
    public interface IHotelAnimal
    {
        int Id { get; set; }

        int? HotelId { get; set; }

        Hotel Hotel { get; set; }

        int? AnimalId { get; set; }

        Animal Animal { get; set; }

        bool IsDeleted { get; set; }
    }
}