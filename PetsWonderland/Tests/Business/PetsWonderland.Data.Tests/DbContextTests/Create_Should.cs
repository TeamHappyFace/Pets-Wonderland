using NUnit.Framework;
using PetsWonderland.Business.Data;
using PetsWonderland.Business.Data.Contracts;

namespace PetsWonderland.Data.Tests.DbContextTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ShouldReturnNewDbContextInstance()
        {
            // Arrange & Act
            var newContext = PetsWonderlandDbContext.Create();

            // Assert
            Assert.IsNotNull(newContext);
            Assert.IsInstanceOf<IPetsWonderlandDbContext>(newContext);          
        }
    }
}
