using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
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
			// Arange
            var dbContext = new PetsWonderlandDbContext();

			// Act & Assert
            Assert.IsInstanceOf<IPetsWonderlandDbContext>(dbContext);
        }

        [Test]
        public void SaveChanges_ShouldWorkCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Animal>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act            
            animalService.AddAnimal(new Animal());

            // Assert
            mockedUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
