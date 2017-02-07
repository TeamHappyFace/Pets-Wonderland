using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		public void ReturnCorrectCount_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validAnimal = new Mock<Animal>();
			mockedRepository.Setup(repository => repository.Add(validAnimal.Object));

			//Assert
			Assert.Positive(animalService.Count());
		}
	}
}
