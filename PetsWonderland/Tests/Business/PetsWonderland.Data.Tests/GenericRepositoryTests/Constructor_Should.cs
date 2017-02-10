using System;
using System.Data.Entity;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Data.Repositories;
using PetsWonderland.Business.Models.Animals.Contracts;

namespace PetsWonderland.Data.Tests.GenericRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenIPetsWonderlandDbContextIsNull()
        {
            // Arrange              
            IPetsWonderlandDbContext nullContext = null;
        
            // Act & Assert
            Assert.That(() => new GenericRepository<IAnimal>(nullContext), 
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Db context is null!"));
        }

        [Test]
        public void ShouldWorkCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<IPetsWonderlandDbContext>();
            var mockedModel = new Mock<DbSet<IAnimal>>();
            mockedContext.Setup(x => x.Set<IAnimal>()).Returns(mockedModel.Object);

            // Act
            var repository = new GenericRepository<IAnimal>(mockedContext.Object);

            // Assert
            Assert.That(repository, Is.Not.Null);
        }

        [Test]
        public void ShouldSetContextCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<IPetsWonderlandDbContext>();
            var mockedModel = new Mock<DbSet<IAnimal>>();
            mockedContext.Setup(x => x.Set<IAnimal>()).Returns(mockedModel.Object);

            // Act
            var repository = new GenericRepository<IAnimal>(mockedContext.Object);

            // Assert
            Assert.That(repository.Context, Is.Not.Null);
            Assert.That(repository.Context, Is.EqualTo(mockedContext.Object));
        }

        [Test]
        public void ShouldSetDbSetCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<IPetsWonderlandDbContext>();
            var mockedModel = new Mock<DbSet<IAnimal>>();
            mockedContext.Setup(x => x.Set<IAnimal>()).Returns(mockedModel.Object);

            // Act
            var repository = new GenericRepository<IAnimal>(mockedContext.Object);

            // Assert
            Assert.That(repository.DbSet, Is.Not.Null);
            Assert.That(repository.DbSet, Is.EqualTo(mockedModel.Object));
        }

        [Test]
        public void Testtt()
        {
            // Arrange
            var mockedContext = new Mock<IPetsWonderlandDbContext>();
            var mockedModel = new Mock<DbSet<IAnimal>>();
            mockedContext.Setup(x => x.Set<IAnimal>()).Returns(mockedModel.Object);


            // Act
            var repository = new GenericRepository<IAnimal>(mockedContext.Object);

            // Assert
            Assert.That(repository.DbSet, Is.Not.Null);
            Assert.That(repository.DbSet, Is.EqualTo(mockedModel.Object));
        }
    }
}
