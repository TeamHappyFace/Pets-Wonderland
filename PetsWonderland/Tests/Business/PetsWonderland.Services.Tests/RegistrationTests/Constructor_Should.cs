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
    public class Constructor_Should
    {
        [Test]
        public void CreateHotelService_WhenParamsAreValid()
        {
            var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
			var mockedAdminRepository = new Mock<IRepository<Admin>>();
			var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
           
            var registrationService = new RegistrationService(
                mockedRoleRepository.Object,
                mockedUserRepository.Object,
				mockedAdminRepository.Object,
                mockedHotelManagerRepository.Object,
                mockedUnitOfWork.Object
            );

            Assert.That(registrationService, Is.InstanceOf<RegistrationService>());
        }

        [Test]
        public void ThrowNullException_WhenRoleRepositoryIsNull()
        {
            Mock<IRepository<ApplicationRole>> mockedRoleRepository = null;
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
			var mockedAdminRepository = new Mock<IRepository<Admin>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			
            Assert.Throws<NullReferenceException>(() => 
                new RegistrationService(
                    mockedRoleRepository.Object,
                    mockedUserRepository.Object,
					mockedAdminRepository.Object,
                    mockedHotelManagerRepository.Object,
                    mockedUnitOfWork.Object
                )
            );
        }

        [Test]
        public void ThrowNullException_WhenUserRepositoryIsNull()
        {
            var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
            Mock<IRepository<RegularUser>> mockedUserRepository = null;         
            var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
			var mockedAdminRepository = new Mock<IRepository<Admin>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			
            Assert.Throws<NullReferenceException>(() =>
                new RegistrationService(
                    mockedRoleRepository.Object,
                    mockedUserRepository.Object,
					mockedAdminRepository.Object,
                    mockedHotelManagerRepository.Object,
                    mockedUnitOfWork.Object
                )
            );
        }

        [Test]
        public void ThrowNullException_WhenHotelManagerRepositoryIsNull()
        {
            var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
			var mockedAdminRepository = new Mock<IRepository<Admin>>();
			Mock<IRepository<HotelManager>> mockedHotelManagerRepository = null;   
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
			
            Assert.Throws<NullReferenceException>(() =>
                new RegistrationService(
                    mockedRoleRepository.Object,
                    mockedUserRepository.Object,
					mockedAdminRepository.Object,
                    mockedHotelManagerRepository.Object,
                    mockedUnitOfWork.Object
                )
            );
        }

		[Test]
		public void ThrowNullException_WhenAdminRepositoryIsNull()
		{
			var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
			var mockedUserRepository = new Mock<IRepository<RegularUser>>();
			var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
			Mock<IRepository<Admin>> mockedAdminRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			
			Assert.Throws<NullReferenceException>(() =>
				new RegistrationService(
					mockedRoleRepository.Object,
					mockedUserRepository.Object,
					mockedAdminRepository.Object,
					mockedHotelManagerRepository.Object,
					mockedUnitOfWork.Object
				)
			);
		}

		[Test]
        public void ThrowNullException_WhenUnitofworkIsNull()
        {
            var mockedRoleRepository = new Mock<IRepository<ApplicationRole>>();
            var mockedUserRepository = new Mock<IRepository<RegularUser>>();
            var mockedHotelManagerRepository = new Mock<IRepository<HotelManager>>();
			var mockedAdminRepository = new Mock<IRepository<Admin>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;
			
            Assert.Throws<NullReferenceException>(() =>
                new RegistrationService(
                    mockedRoleRepository.Object,
                    mockedUserRepository.Object,
					mockedAdminRepository.Object,
                    mockedHotelManagerRepository.Object,
                    mockedUnitOfWork.Object
                )
            );              
        }
    }
}
