using System;
using System.Text;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.AnimalTests
{
	[TestFixture]
	public class GetAllAnimals_Should
	{
		[Test]
		public void TestMethod1()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act

			//Assert
		}
	}
}
