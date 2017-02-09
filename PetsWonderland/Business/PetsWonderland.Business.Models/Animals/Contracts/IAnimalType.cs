namespace PetsWonderland.Business.Models.Animals.Contracts
{
    public interface IAnimalType
    {
        int Id { get; set; }

        string Name { get; set; }

        bool IsDeleted { get; set; }
    }
}