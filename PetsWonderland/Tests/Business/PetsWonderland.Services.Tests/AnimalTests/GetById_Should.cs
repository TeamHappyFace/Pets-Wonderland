using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.AnimalTests
{
	[TestFixture]
	public class GetById_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var animal = new Mock<Animal>();
			animalService.GetById(animal.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.GetById(animal.Object.Id), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotUsed()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedRepository.Verify(repository => repository.GetById(1), Times.Never);
		}

		[Test]
		public void ReturnAnimal_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			var animal = new Mock<Animal>();
			mockedRepository.Setup(repository => repository.GetById(animal.Object.Id)).Returns(() => animal.Object);

			//Act, Assert
			Assert.IsInstanceOf<Animal>(animalService.GetById(animal.Object.Id));
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var animal = new Mock<Animal>();
			mockedRepository.Setup(repository => repository.GetById(animal.Object.Id)).Returns(() => animal.Object);

			//Assert
			Assert.AreEqual(animalService.GetById(animal.Object.Id), animal.Object);
		}

		[Test]
		public void ReturnCorrectAnimal_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var animal = new Mock<Animal>();
			var animalToCompare = new Mock<Animal>();
			mockedRepository.Setup(repository => repository.GetById(animal.Object.Id)).Returns(() => animal.Object);

			//Assert
			Assert.AreNotEqual(animalService.GetById(animal.Object.Id), animalToCompare.Object);
		}

		[Test]
		public void NotReturnAnimal_WhenNoSuchAnimal()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			mockedRepository.Setup(repository => repository.GetById(0)).Returns(() => null);

			//Assert
			Assert.IsNull(animalService.GetById(0));
		}

		[Test]
		public void ThrowException_WhenNullAnimal()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			Mock<Animal> animal = null;

			//Assert
			Assert.Throws<NullReferenceException>(()=>animalService.GetById(animal.Object.Id));
		}
	}
}
