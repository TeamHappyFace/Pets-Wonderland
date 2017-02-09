using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.AnimalTests
{
	[TestFixture]
	public class GetAnimalType_Should
	{
		[Test]
		public void ReturnCorrectAnimalType_WhenAnimalIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			var animalType = new AnimalType() { Name = "Dog" };
			validAnimal.Setup(animal => animal.AnimalType).Returns(animalType);

			//Assert
			Assert.AreEqual(animalType, animalService.GetAnimalType(validAnimal.Object));
		}

		[Test]
		public void ReturnInstanceAnimalType_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			var animalType = new AnimalType() { Name = "Dog" };
			validAnimal.Setup(animal => animal.AnimalType).Returns(animalType);

			//Assert
			Assert.IsInstanceOf<AnimalType>(validAnimal.Object.AnimalType);
		}

		[Test]
		public void ReturnsNull_WhenNoAnimalTypeIsNotAssigned()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();

			//Assert
			Assert.IsNull(animalService.GetAnimalType(validAnimal.Object));
		}

		[Test]
		public void ThrowException_WhenAnimalIsNull()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			Mock<Animal> validAnimal = null;

			//Assert
			Assert.That(() => animalService.GetAnimalType(validAnimal.Object),
				Throws.InstanceOf<NullReferenceException>());
		}
	}
}
