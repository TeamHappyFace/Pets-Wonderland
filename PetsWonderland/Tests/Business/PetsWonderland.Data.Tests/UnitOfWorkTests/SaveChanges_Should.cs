using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Data.UnitOfWork;

namespace PetsWonderland.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class SaveChanges_Should
    {
        [Test]
        public void InvokeDbContextOnce()
        {
            var mockedContext = new Mock<IPetsWonderlandDbContext>();
            var unitOfWork = new UnitOfWork(mockedContext.Object);

            unitOfWork.SaveChanges();

            mockedContext.Verify(mock => mock.SaveChanges(), Times.Once());
        }
    }
}
