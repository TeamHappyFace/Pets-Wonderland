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
    public class GetById_Should
    {
        //[Test]
        //public void ThrowException_WhenargumentIsInvalid()
        //{
        //    var mockedDbSet = new Mock<DbSet<IAnimal>>();
        //    var mockedDbContext = new Mock<IPetsWonderlandDbContext>();
        //    mockedDbContext.Setup(mock => mock.Set<IAnimal>()).Returns(mockedDbSet.Object);

        //    var animalRepository = new GenericRepository<IAnimal>(mockedDbContext.Object);
        //    var fakeId = -15;

        //    Assert.That(
        //        () => animalRepository.GetById(fakeId),
        //        Throws.InstanceOf<ArgumentException>().With.Message.Contains("Id msut be a positive number!"));
        //}

        [Test]
        public void ReturnCorrectResult_WhenParameterIsValid()
        {
            var mockedDbSet = new Mock<DbSet<IAnimal>>();
            var mockedDbContext = new Mock<IPetsWonderlandDbContext>();
            mockedDbContext.Setup(mock => mock.Set<IAnimal>()).Returns(mockedDbSet.Object);

            var animalRepository = new GenericRepository<IAnimal>(mockedDbContext.Object);

            var fakeAnimal = new Mock<IAnimal>();
            mockedDbSet.Setup(x => x.Find(It.IsAny<int>())).Returns(fakeAnimal.Object);

            var validId = 15;
            Assert.That(animalRepository.GetById(validId), Is.Not.Null);
            Assert.AreEqual(animalRepository.GetById(validId), fakeAnimal.Object);
        }
    }
}
