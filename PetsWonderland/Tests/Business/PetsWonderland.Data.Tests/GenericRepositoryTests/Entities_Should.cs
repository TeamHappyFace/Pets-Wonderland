using System.Data.Entity;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Data.Repositories;
using PetsWonderland.Business.Models.Animals.Contracts;

namespace PetsWonderland.Data.Tests.GenericRepositoryTests
{
    [TestFixture]
    public class Entities_Should
    {
        [Test]
        public void ReturnTheCorrectDbSet()
        {
            var mockedContext = new Mock<IPetsWonderlandDbContext>();
            var mockedSet = new Mock<IDbSet<IAnimal>>();

            mockedContext.Setup(x => x.Set<IAnimal>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<IAnimal>(mockedContext.Object);

            Assert.NotNull(repository.Entities);
            Assert.IsInstanceOf(typeof(IDbSet<IAnimal>), repository.Entities);
            Assert.AreSame(repository.Entities, repository.DbSet);
        }
    }
}
