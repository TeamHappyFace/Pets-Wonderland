using System.Linq;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository<Animal> _animalRepository;

        public AnimalService(IRepository<Animal> animalRepository)
        {
            this._animalRepository = animalRepository;
        }     

        public IQueryable<Animal> GetAllAnimals()
        {
            return this._animalRepository.All();
        }
    }
}
