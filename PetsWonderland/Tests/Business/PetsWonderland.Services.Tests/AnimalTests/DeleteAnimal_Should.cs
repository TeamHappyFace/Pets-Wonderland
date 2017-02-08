using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using PetsWonderland.Business.Services;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using Moq;

namespace PetsWonderland.Services.Tests.AnimalTests
{
	[TestFixture]
	public class DeleteAnimal_Should
	{
		[Test]
		public void InvokeDeleteMethod_WhenAnimaltoDeleteIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);
			animalService.DeleteAnimal(validAnimal.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(validAnimal.Object));
		}

		[Test]
		public void InvokeDeleteMethodOnceForAnimal_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);
			animalService.DeleteAnimal(validAnimal.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(It.IsAny<Animal>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesTwice_WhenAnimalIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);
			animalService.DeleteAnimal(validAnimal.Object);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Exactly(2));
		}

		[Test]
		public void NotDeleteAnimal_WhichIsNotAdded()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			var animal = new Mock<Animal>();

			//Act, Assert
			mockedRepository.Verify(repository => repository.Delete(animal.Object), Times.Never);
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
			Assert.Throws<NullReferenceException>(() => animalService.DeleteAnimal(animal.Object));
		}
	}
}
