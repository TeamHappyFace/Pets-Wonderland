namespace PetsWonderland.Business.Models.Animals.Contracts
{
    public interface IAnimal
    {
        int Id { get; set; }

        string Name { get; set; }

        int Age { get; set; }

        string AvatarUrl { get; set; }

        string Description { get; set; }

        int? AnimalTypeId { get; set; }

        AnimalType AnimalType { get; set; }

        bool IsDeleted { get; set; }
    }
}