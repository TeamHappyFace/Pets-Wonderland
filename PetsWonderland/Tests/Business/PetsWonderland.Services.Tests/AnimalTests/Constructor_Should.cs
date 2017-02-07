using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.AnimalTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateAnimalService_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			//Act
			var hotelService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Assert
			Assert.That(hotelService, Is.InstanceOf<AnimalService>());
		}

		[Test]
		public void ThrowNullException_WhenRepositoryIsNull()
		{
			//Arrange
			Mock<IRepository<Animal>> mockedRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object));
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Animal>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object));
		}
	}
}
