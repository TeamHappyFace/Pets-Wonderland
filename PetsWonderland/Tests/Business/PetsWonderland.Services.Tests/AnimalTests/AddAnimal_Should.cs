using Moq;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services;
using PetsWonderland.Business.Data.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PetsWonderland.Business.Tests.Services.AnimalServiceTests
{
	[TestFixture]
	public class AddAnimal_Should
	{
		[Test]
		public void InvokeAddMethod_WhenAnimalIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(validAnimal.Object));
		}

		[Test]
		public void InvokeAddMethodOnceForAnimal_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(It.IsAny<Animal>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenAnimalIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenAnimalIsInvalid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			Mock<Animal> animalToAdd = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => animalService.AddAnimal(animalToAdd.Object));
		}
	}
}
