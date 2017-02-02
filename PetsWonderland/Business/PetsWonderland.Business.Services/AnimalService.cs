using System.Linq;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository<Animal> animalRepository;

        public AnimalService(IRepository<Animal> animalRepository)
        {
            this.animalRepository = animalRepository;
        }

		public void AddAnimal(Animal animalToAdd)
		{
			this.animalRepository.Add(animalToAdd);
		}

		public void DeleteAnimal(Animal animalToDelete)
		{
			this.animalRepository.Delete(animalToDelete);
		}

		public void DeleteAnimalById(object animalId)
		{
			this.animalRepository.Delete(animalId);
		}

		public IQueryable<Animal> GetAllAnimals()
        {
            return this.animalRepository.All();
        }

		public AnimalType GetAnimalType(Animal animal)
		{
			return animal.AnimalType;
		}

		public Animal GetById(int id)
		{
			return this.animalRepository.GetById(id);
		}

		public Animal GetByName(string name)
		{
			return this.animalRepository.GetByName(name);
		}
	}
}
