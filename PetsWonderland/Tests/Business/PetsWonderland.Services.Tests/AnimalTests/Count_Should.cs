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
	public class Count_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);
			animalService.Count();

			//Assert
			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);

			//Assert
			mockedRepository.Verify(repository => repository.All(), Times.Never);
		}

		[Test]
		public void ReturnExactNumber_WhenParamsAreValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<Animal> result = new List<Animal>() { new Animal(), new Animal(), new Animal() };
			mockedRepository.Setup(repo => repo.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.AreEqual(3, animalService.Count());
		}

		[Test]
		public void ReturnZero_WhenNoAnimals()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<Animal> result = new List<Animal>();
			mockedRepository.Setup(repo => repo.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.AreEqual(0, animalService.Count());
		}
	}
}
