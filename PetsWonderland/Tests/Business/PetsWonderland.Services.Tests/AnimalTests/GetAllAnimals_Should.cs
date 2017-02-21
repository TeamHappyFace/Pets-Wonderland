using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.AnimalTests
{
	[TestFixture]
	public class GetAllAnimals_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			animalService.GetAllAnimals();
			
			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void ReturnIqueriable_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Animal> result = new List<Animal>() { new Animal(), new Animal(), new Animal() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.IsInstanceOf<IQueryable<Animal>>(animalService.GetAllAnimals());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<Animal> result = new List<Animal>() { new Animal(), new Animal(), new Animal() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.AreEqual(animalService.GetAllAnimals(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoAnimals()
		{
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<Animal> result = new List<Animal>();
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.IsEmpty(animalService.GetAllAnimals());
		}

		[Test]
		public void ThrowException_WhenNullAnimal()
		{
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<Animal> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.Throws<ArgumentNullException>(() => animalService.GetAllAnimals());
		}
	}
}
