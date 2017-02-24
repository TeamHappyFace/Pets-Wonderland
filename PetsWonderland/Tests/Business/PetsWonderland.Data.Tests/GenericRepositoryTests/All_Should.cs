using System.Data.Entity;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Data.Repositories;
using PetsWonderland.Business.Models.Animals.Contracts;

namespace PetsWonderland.Data.Tests.GenericRepositoryTests
{
    [TestFixture]
    public class All_Should
    {
        [Test]
        public void ReturnEntitiesOfThisSet()
        {
            var mockedContext = new Mock<IPetsWonderlandDbContext>();
            var mockedSet = new Mock<IDbSet<IAnimal>>();

            mockedContext.Setup(x => x.Set<IAnimal>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<IAnimal>(mockedContext.Object);

            Assert.NotNull(repository.All());
            Assert.IsInstanceOf(typeof(IDbSet<IAnimal>), repository.All());
            Assert.AreSame(repository.All(), repository.DbSet);
        }
    }
}
