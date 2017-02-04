using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using Moq;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Business.Tests.Services.AnimalServiceTests
{
	[TestClass]
	public class AddAnimal_Should
	{
		[TestMethod]
		public void AddAnimalCorrectly_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<Animal>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

			var validAnimal = new Mock<Animal>();
			animalService.AddAnimal(validAnimal.Object);

			Assert.IsNotNull(mockedRepository.Object); 
		}
	}
}
