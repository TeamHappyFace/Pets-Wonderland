using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Animals.Contracts
{
    public interface IUserAnimal
    {
        int Id { get; set; }

        string UserId { get; set; }

        RegularUser User { get; set; }

        int? AnimalId { get; set; }

        Animal Animal { get; set; }

        bool IsDeleted { get; set; }
    }
}