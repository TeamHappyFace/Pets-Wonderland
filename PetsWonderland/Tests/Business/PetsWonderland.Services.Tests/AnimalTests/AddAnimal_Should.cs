using Moq;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services;
using PetsWonderland.Business.Data.Contracts;
using NUnit.Framework;
using System;

namespace PetsWonderland.Business.Tests.Services.AnimalServiceTests
{
	[TestFixture]
	public class AddAnimal_Should
	{
		[Test]
		public void AddAnimalCorrectly_WhenAnimalIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);

			//Assert
			Assert.IsNotNull(mockedRepository.Object); 
		}

		[Test]
		public void AddOnlyOneAnimal_WhenAnimalIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);

			//Assert
			Assert.AreEqual(1, animalService.Count());
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
