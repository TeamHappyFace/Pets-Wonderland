using System;
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
		public void CallCountMethod_WhenParamsAreValid()
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
		public void NotCallCountMethod_WhenParamsAreValid()
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
	}
}
