using System;
using System.Reflection;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Data.UnitOfWork;

namespace PetsWonderland.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextParameterIsNull()
        {
            IPetsWonderlandDbContext nullContext = null;

            Assert.That(
                () => new UnitOfWork(nullContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Db context is null!"));
        }

        [Test]
        public void ShouldWork_WhenParametersAreValid()
        {
            var mockDbContext = new Mock<IPetsWonderlandDbContext>();

            var uow = new UnitOfWork(mockDbContext.Object);
           
            Assert.IsNotNull(uow);       
        }

        [Test]
        public void CreateUowThatImplementsIDisposableAndIUnitOfWork_WhenParametersAreValid()
        {
            var mockDbContext = new Mock<IPetsWonderlandDbContext>();

            var uow = new UnitOfWork(mockDbContext.Object);

            Assert.IsInstanceOf<IDisposable>(uow);
            Assert.IsInstanceOf<IUnitOfWork>(uow);
        }
    }
}
