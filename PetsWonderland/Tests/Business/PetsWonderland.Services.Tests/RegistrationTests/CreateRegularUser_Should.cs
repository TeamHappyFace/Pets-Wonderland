using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.UserRoles;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.RegistrationTests
{
    [TestFixture]
    public class CreateRegularUser_Should
	{
		[Test]
		public void InvokeAddMethod_WhenParamsAreValid()
		{
			var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
			var mockedUserRepository = new Mock<IRepository<RegularUser>>();
			var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
			var mockedAdminRepository = new Mock<IRepository<Admin>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var registrationService = new RegistrationService(
				mockedRoleRepository.Object,
				mockedUserRepository.Object,
				mockedAdminRepository.Object,
				mockedHotelManagerRepository.Object,
				mockedUnitOfWork.Object
			);

			mockedUserRepository.Setup(repository => repository.Add(It.IsAny<RegularUser>()));
			registrationService.CreateRegularUser("1");

			mockedUserRepository.Verify(repository => repository.Add(It.IsAny<RegularUser>()), Times.Once);
		}

		[Test]
		public void InvokeSaveChanges_WhenRegularUserIsValid()
		{
			var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
			var mockedUserRepository = new Mock<IRepository<RegularUser>>();
			var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
			var mockedAdminRepository = new Mock<IRepository<Admin>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			var registrationService = new RegistrationService(
				mockedRoleRepository.Object,
				mockedUserRepository.Object,
				mockedAdminRepository.Object,
				mockedHotelManagerRepository.Object,
				mockedUnitOfWork.Object
			);

			mockedUserRepository.Setup(repository => repository.Add(It.IsAny<RegularUser>()));
			registrationService.CreateRegularUser("1");

			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}
		
        [Test]
        public void ThrowException_WhenIdIsEmpty()
        {
            var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
			var mockedAdminRepository = new Mock<IRepository<Admin>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var registrationService = new RegistrationService(
                mockedRoleRepository.Object,
                mockedUserRepository.Object,
				mockedAdminRepository.Object,
                mockedHotelManagerRepository.Object,
                mockedUnitOfWork.Object
            );
			
            Assert.Throws<ArgumentException>(() => registrationService.CreateRegularUser(string.Empty));
        }
    }
}