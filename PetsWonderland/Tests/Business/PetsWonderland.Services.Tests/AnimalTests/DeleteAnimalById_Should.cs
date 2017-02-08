using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.AnimalTests
{
	[TestFixture]
	public class DeleteAnimalById_Should
	{
		[Test]
		public void BeInvoked_WhenAnimaltoDeleteIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);
			animalService.DeleteAnimalById(validAnimal.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(validAnimal.Object.Id));
		}

		[Test]
		public void BeInvokedOnceForTypeAnimal_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);
			animalService.DeleteAnimalById(validAnimal.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(validAnimal.Object.Id), Times.Once);
		}

		[Test]
		public void CallSaveChangesTwice_WhenParamsAreValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);
			animalService.DeleteAnimalById(validAnimal.Object.Id);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Exactly(2));
		}

		[Test]
		public void NotDeleteByIdAnimal_WhichIsNotAdded()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			var animal = new Mock<Animal>();

			//Act, Assert
			mockedRepository.Verify(repository => repository.Delete(animal.Object.Id), Times.Never);
		}

		[Test]
		public void ThrowException_WhenAimalIsNull()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<Animal> animal = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => animalService.DeleteAnimalById(animal.Object.Id));
		}
	}
}
