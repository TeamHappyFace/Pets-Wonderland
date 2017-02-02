using System.Linq;
using PetsWonderland.Business.Models.Animals;

namespace PetsWonderland.Business.Services.Contracts
{
    public interface IAnimalService
    {
        IQueryable<Animal> GetAllAnimals();
		Animal GetById(int id);
		Animal GetByName(string name);

		AnimalType GetAnimalType(Animal animal);

		void AddAnimal(Animal animalToAdd);
		void DeleteAnimal(Animal animalToDelete);
		void DeleteAnimalById(object animalId);
	}
}