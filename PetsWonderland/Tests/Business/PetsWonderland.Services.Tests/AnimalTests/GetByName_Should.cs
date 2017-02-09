using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.AnimalTests
{
	[TestFixture]
	public class GetByName_Should
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
			animalService.GetByName(animal.Object.Name);

			//Assert
			mockedRepository.Verify(repository => repository.GetByName(animal.Object.Name), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotUsed()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedRepository.Verify(repository => repository.GetByName("Pesho"), Times.Never);
		}

		[Test]
		public void ReturnAnimal_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var animal = new Mock<Animal>();
			mockedRepository.Setup(repository => repository.GetByName(animal.Object.Name)).Returns(() => animal.Object);

			//Assert
			Assert.IsInstanceOf<Animal>(animalService.GetByName(animal.Object.Name));
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
			mockedRepository.Setup(repository => repository.GetByName(animal.Object.Name)).Returns(() => animal.Object);

			//Assert
			Assert.AreEqual(animalService.GetByName(animal.Object.Name), animal.Object);
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
			mockedRepository.Setup(repository => repository.GetByName(animal.Object.Name)).Returns(() => animal.Object);

			//Assert
			Assert.AreNotEqual(animalService.GetByName(animal.Object.Name), animalToCompare.Object);
		}

		[Test]
		public void NotReturnAnimal_WhenNoSuchAnimal()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			mockedRepository.Setup(repository => repository.GetByName("Zoro")).Returns(() => null);

			//Assert
			Assert.IsNull(animalService.GetByName("Zoro"));
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
			Assert.Throws<NullReferenceException>(() => animalService.GetByName(animal.Object.Name));
		}
	}
}
