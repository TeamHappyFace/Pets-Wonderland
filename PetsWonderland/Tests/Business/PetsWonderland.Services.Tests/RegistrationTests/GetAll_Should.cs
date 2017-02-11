using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.UserRoles;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.RegistrationTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void BeCalled_WhenParamsAreValid()
        {
            //Arrange
            var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var registrationService = new RegistrationService(
                mockedRoleRepository.Object,
                mockedUserRepository.Object,
                mockedHotelManagerRepository.Object,
                mockedUnitOfWork.Object
            );

            //Act
            registrationService.GetAllUserRoles();

            //Assert
            mockedRoleRepository.Verify(repository => repository.All(), Times.Once);
        }

        [Test]
        public void NotBeCalled_WhenNotUsed()
        {
            //Arange
            var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var registrationService = new RegistrationService(
                mockedRoleRepository.Object,
                mockedUserRepository.Object,
                mockedHotelManagerRepository.Object,
                mockedUnitOfWork.Object
            );

            //Act, Assert
            mockedRoleRepository.Verify(repository => repository.All(), Times.Never);
        }

        [Test]
        public void ReturnIqueriable_WhenInvoked()
        {
            //Arange
            var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var registrationService = new RegistrationService(
                mockedRoleRepository.Object,
                mockedUserRepository.Object,
                mockedHotelManagerRepository.Object,
                mockedUnitOfWork.Object
            );

            IEnumerable<ApplicationRole> result = new List<ApplicationRole>() { new ApplicationRole(), new ApplicationRole() };
            mockedRoleRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

            //Act, Assert
            Assert.IsInstanceOf<IQueryable<ApplicationRole>>(registrationService.GetAllUserRoles());
        }

        [Test]
        public void WorksProperly_WhenInvoked()
        {
            //Arange
            var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var registrationService = new RegistrationService(
                mockedRoleRepository.Object,
                mockedUserRepository.Object,
                mockedHotelManagerRepository.Object,
                mockedUnitOfWork.Object
            );

            //Act
            IEnumerable<ApplicationRole> result = new List<ApplicationRole>() { new ApplicationRole(), new ApplicationRole() };
            mockedRoleRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

            //Assert
            Assert.AreEqual(registrationService.GetAllUserRoles(), result);
        }

        [Test]
        public void ReturnEmptyCollection_WhenNoRoles()
        {
            //Arange
            var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var registrationService = new RegistrationService(
                mockedRoleRepository.Object,
                mockedUserRepository.Object,
                mockedHotelManagerRepository.Object,
                mockedUnitOfWork.Object
            );

            //Act
            IEnumerable<ApplicationRole> result = new List<ApplicationRole>();
            mockedRoleRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

            //Assert
            Assert.IsEmpty(registrationService.GetAllUserRoles());
        }

        [Test]
        public void ThrowException_WhenRoleIsNull()
        {
            //Arange
            var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var registrationService = new RegistrationService(
                mockedRoleRepository.Object,
                mockedUserRepository.Object,
                mockedHotelManagerRepository.Object,
                mockedUnitOfWork.Object
            );

            //Act
            IEnumerable<ApplicationRole> result = null;
            mockedRoleRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

            //Assert
            Assert.Throws<ArgumentNullException>(() => registrationService.GetAllUserRoles());
        }
    }
}
