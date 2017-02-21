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
            var context = new PetsWonderlandDbContext();

            Assert.IsInstanceOf<PetsWonderlandDbContext>(context);
        }

        [Test]
        public void Return_InstanceOfIPetsWonderlandDbContext()
        {
            var context = new PetsWonderlandDbContext();

            Assert.IsInstanceOf<IPetsWonderlandDbContext>(context);
        }

        [Test]
        public void SaveChanges_ShouldWorkCorrectly()
        {
            var mockedRepository = new Mock<IRepository<Animal>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var animalService = new AnimalService(mockedRepository.Object, mockedUnitOfWork.Object);
         
            animalService.AddAnimal(new Animal());

            mockedUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
