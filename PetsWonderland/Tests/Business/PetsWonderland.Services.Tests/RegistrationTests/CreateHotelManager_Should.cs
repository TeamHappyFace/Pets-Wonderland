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
	public class CreateHotelManager_Should
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

			mockedHotelManagerRepository.Setup(repository => repository.Add(It.IsAny<HotelManager>()));
			registrationService.CreateHotelManager("1");

			mockedHotelManagerRepository.Verify(repository => repository.Add(It.IsAny<HotelManager>()), Times.Once);
		}

		[Test]
		public void InvokeSaveChanges_WhenHotelManagerIsValid()
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

			mockedHotelManagerRepository.Setup(repository => repository.Add(It.IsAny<HotelManager>()));
			registrationService.CreateHotelManager("1");

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

			Assert.Throws<ArgumentException>(() => registrationService.CreateHotelManager(string.Empty));
		}
	}
}
