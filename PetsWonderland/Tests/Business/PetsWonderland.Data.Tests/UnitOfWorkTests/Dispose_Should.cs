using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class Dispose_Should
    {
        [Test]
        public void BeDisposedCorrectly()
        { 
            var mockRepository = new Mock<IRepository<Animal>>();
            var mockUow = new Mock<IUnitOfWork>();

            var animalService = new AnimalService(mockRepository.Object, mockUow.Object);
           
            using (var uw = mockUow.Object)
            {
                var animals = animalService.GetAllAnimals();
            }
                            
            mockUow.Verify(m => m.Dispose(), Times.Exactly(1));
        }
    }
}
