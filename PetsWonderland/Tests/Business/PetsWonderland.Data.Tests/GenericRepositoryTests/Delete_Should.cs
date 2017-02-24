using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Data.Repositories;
using PetsWonderland.Business.Models.Animals.Contracts;

namespace PetsWonderland.Data.Tests.GenericRepositoryTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenArgumentIsNull()
        {
            var mockedSet = new Mock<DbSet<IAnimal>>();
            var mockedDbContext = new Mock<IPetsWonderlandDbContext>();
            mockedDbContext.Setup(mock => mock.Set<IAnimal>()).Returns(mockedSet.Object);

            var animalRepository = new GenericRepository<IAnimal>(mockedDbContext.Object);
            IAnimal entity = null;

            Assert.That(
                () => animalRepository.Delete(entity),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Entity cannot be null!"));
        }

        [Test]
        public void NotThrow_WhenArgumentIsValid()
        {
            var mockedSet = new Mock<IDbSet<IAnimal>>();
            var mockedAnimal = new Mock<IAnimal>();
            mockedAnimal.SetupAllProperties();

            var mockedContext = new Mock<IPetsWonderlandDbContext>();
            mockedContext.Setup(x => x.Set<IAnimal>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<IAnimal>(mockedContext.Object);

            try
            {
                repository.Delete(mockedAnimal.Object);
            }
            catch (NullReferenceException e) { };

            mockedContext.Verify(x => x.Entry(mockedAnimal.Object), Times.AtLeastOnce);
        }
    }
}
