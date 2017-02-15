using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
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
    public class CreateRegularUser_Should
    {        
        [Test]
        public void ThrowException_WhenRegularUserIsInvalid()
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

            Mock<RegularUser> userToAdd = null;

            //Act, Assert
            Assert.Throws<NullReferenceException>(() => registrationService.CreateRegularUser(userToAdd.Object.Id));
        }
    }
}
