using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Data.Repositories;
using PetsWonderland.Business.Models;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Data.Tests.DbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void HaveParameterlessConstructor()
        {
            // Arrange & Act
            var dbContext = new PetsWonderlandDbContext();

            // Assert
            Assert.IsInstanceOf<PetsWonderlandDbContext>(dbContext);
        }

        [Test]
        public void Return_InstanceOfIPetsWonderlandDbContext()
        {
            // Arrange & Act
            var dbContext = new PetsWonderlandDbContext();

            // Assert
            Assert.IsInstanceOf<IPetsWonderlandDbContext>(dbContext);
        }

        [Test]
        public void SaveChanges_ShoulBeCalledOnce()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Animal>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act            
            animalService.AddAnimal(It.IsAny<Animal>());

            // Assert
            mockedUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
