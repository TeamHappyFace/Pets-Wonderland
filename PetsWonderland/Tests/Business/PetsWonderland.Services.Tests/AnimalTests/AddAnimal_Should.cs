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
		public void BeInvoked_WhenAnimalIsValid()
		{
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);
			
			mockedRepository.Verify(repository => repository.Add(validAnimal.Object));
		}

		[Test]
		public void BeInvokeOnceForTypeAnimal_WhenParamsAreCorrect()
		{
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);
			
			mockedRepository.Verify(repository => repository.Add(It.IsAny<Animal>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenAnimalIsValid()
		{
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);
			
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenAnimalIsInvalid()
		{
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			Mock<Animal> animalToAdd = null;
			
			Assert.Throws<NullReferenceException>(() => animalService.AddAnimal(animalToAdd.Object));
		}
	}
}
