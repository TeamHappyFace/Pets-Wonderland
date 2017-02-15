using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.UserRoles;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.Models.Users.Contracts;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.RegistrationTests
{
	[TestFixture]
	public class CreateAdmin_Should
	{
		[Test]
		public void ThrowException_WhenAdminIsInvalid()
		{
			//Arange
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

			Mock<Admin> userToAdd = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => registrationService.CreateAdmin(userToAdd.Object.Id));
		}

		[Test]
		public void InvokeSaveChanges_WhenAdminIsValid()
		{
			//Arange
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

			//Act
			var userToAdd = new Mock<IAdmin>() { Name = "Ivan" };
			userToAdd.Setup(user => user.Id).Returns("a");
			registrationService.CreateAdmin(userToAdd.Object.Id);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}
	}
}
