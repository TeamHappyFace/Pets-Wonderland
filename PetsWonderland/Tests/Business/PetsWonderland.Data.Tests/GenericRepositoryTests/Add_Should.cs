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
    public class Add_Should
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
                () => animalRepository.Add(entity),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Entity cannot be null!"));
        }
    }
}
