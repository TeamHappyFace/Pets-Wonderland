using System.Linq;
using PetsWonderland.Business.Models.Animals;

namespace PetsWonderland.Business.Services.Contracts
{
    public interface IAnimalService
    {
        IQueryable<Animal> GetAllAnimals();

        Animal GetById(int id);
		
        void AddAnimal(Animal animalToAdd);
    }
}