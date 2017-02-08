using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Models.Tests.UsersTests
{
    [TestFixture]
    public class AdminTests
    {
        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var admin = new Admin();

            // Assert
            Assert.IsInstanceOf<Admin>(admin);
        }

        [Test]
        public void Constructor_ShouldInitializeHotelRegistratioNRequestsCollectionCorrectly()
        {
            var admin = new Admin();
                    
            var registrationRequests = admin.UserHotelRegistrationRequests;

            Assert.That(registrationRequests, Is.Not.Null.And.InstanceOf<HashSet<UserHotelRegistrationRequest>>());
        }

        [TestCase(123)]
        [TestCase(12)]
        public void RegistrationRequestCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            var registrationRequest = new UserHotelRegistrationRequest { Id = testId };
            var set = new HashSet<UserHotelRegistrationRequest> { registrationRequest };

            var admin = new Admin { UserHotelRegistrationRequests = set };

            Assert.AreEqual(admin.UserHotelRegistrationRequests.First().Id, testId);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var admin = new Admin { IsDeleted = testIsDeleted };

            //Assert
            Assert.AreEqual(admin.IsDeleted, testIsDeleted);
        }
    }
}
