using System;
using System.Linq;
using Bytes2you.Validation;
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
            Guard.WhenArgument(animalRepository, "Animal repository is null!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

            this.animalRepository = animalRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddAnimal(Animal animalToAdd)
        {
            Guard.WhenArgument(animalToAdd, "Animal to add is null!").IsNull().Throw();

            using (var unitOfWork = this.unitOfWork)
            {
                this.animalRepository.Add(animalToAdd);
                unitOfWork.SaveChanges();
            }
        }

        public int Count()
        {
            return this.animalRepository.All().Count();
        }

        public void DeleteAnimal(Animal animalToDelete)
        {
            Guard.WhenArgument(animalToDelete, "Animal to delete is null!").IsNull().Throw();

            using (var unitOfWork = this.unitOfWork)
            {
                this.animalRepository.Delete(animalToDelete);
                this.unitOfWork.SaveChanges();
            }
        }

        public void DeleteAnimalById(object animalId)
        {
            using (var unitOfWork = this.unitOfWork)
            {
                this.animalRepository.Delete(animalId);
                this.unitOfWork.SaveChanges();
            }
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
