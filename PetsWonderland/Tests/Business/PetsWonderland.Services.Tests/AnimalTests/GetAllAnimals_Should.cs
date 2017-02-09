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
			//Arrange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			animalService.GetAllAnimals();

			//Assert
			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotUsed()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			//Act, Assert
			mockedRepository.Verify(repository => repository.All(), Times.Never);
		}

		[Test]
		public void ReturnIqueriable_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Animal> result = new List<Animal>() { new Animal(), new Animal(), new Animal() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Act, Assert
			Assert.IsInstanceOf<IQueryable<Animal>>(animalService.GetAllAnimals());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<Animal> result = new List<Animal>() { new Animal(), new Animal(), new Animal() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.AreEqual(animalService.GetAllAnimals(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoAnimals()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<Animal> result = new List<Animal>();
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.IsEmpty(animalService.GetAllAnimals());
		}

		[Test]
		public void ThrowException_WhenNullAnimal()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<Animal> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.Throws<ArgumentNullException>(() => animalService.GetAllAnimals());
		}
	}
}
