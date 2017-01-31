using System;
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

        public IQueryable<Animal> GetAllAnimals()
        {
            return this.animalRepository.All();
        }

		public Animal GetById(int id)
		{
			return this.animalRepository.GetById(id);
		}
	}
}
