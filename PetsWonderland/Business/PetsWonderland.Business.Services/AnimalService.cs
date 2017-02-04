using System.Linq;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository<Animal> animalRepository;
		private readonly IUnitOfWork unitOfWork;

        public AnimalService(IRepository<Animal> animalRepository, IUnitOfWork unitOfWork)
        {
            this.animalRepository = animalRepository;
			this.unitOfWork = unitOfWork;
        }

		public void AddAnimal(Animal animalToAdd)
		{
			this.animalRepository.Add(animalToAdd);
			this.unitOfWork.SaveChanges();
		}

		public void DeleteAnimal(Animal animalToDelete)
		{
			this.animalRepository.Delete(animalToDelete);
			this.unitOfWork.SaveChanges();
		}

		public void DeleteAnimalById(object animalId)
		{
			this.animalRepository.Delete(animalId);
			this.unitOfWork.SaveChanges();
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
