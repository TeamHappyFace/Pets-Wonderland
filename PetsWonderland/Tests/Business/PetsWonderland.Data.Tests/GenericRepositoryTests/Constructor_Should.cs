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
using PetsWonderland.Business.Models.Animals;

namespace PetsWonderland.Data.Tests.GenericRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenIPetsWonderlandDbCOntextIsNull()
        {
            // Arrange      
        
            var mockedSet = new Mock<DbSet<Animal>>();
            var mockedContext = new Mock<IPetsWonderlandDbContext>();
            mockedContext.Setup(x => x.Set<Animal>()).Returns(mockedSet.Object);

             
            // Act & Assert
            Assert.That(() => new GenericRepository<Animal>(nullContext), 
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Db context is null!"));
        }

        public void ShouldWorkCorrectly_WhenValidArgumentsPassed()
        {
            
        }
    }
}
