using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.AnimalTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateAnimalService_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			Assert.That(animalService, Is.InstanceOf<AnimalService>());
		}

		[Test]
		public void ThrowNullException_WhenRepositoryIsNull()
		{
			Mock<IRepository<Animal>> mockedRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			
			Assert.Throws<NullReferenceException>(() => new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object));
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			var mockedRepository = new Mock<IRepository<Animal>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;
			
			Assert.Throws<NullReferenceException>(() => new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object));
		}
	}
}
