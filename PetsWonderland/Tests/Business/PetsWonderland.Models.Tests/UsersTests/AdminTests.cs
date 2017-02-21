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
            var admin = new Admin();

            Assert.IsInstanceOf<Admin>(admin);
        }

        [Test]
        public void Constructor_ShouldInitializeHotelRegistratioNRequestsCollectionCorrectly()
        {
            var admin = new Admin();
                    
            var registrationRequests = admin.UserHotelRegistrationRequests;

            Assert.That(registrationRequests, Is.Not.Null.And.InstanceOf<HashSet<UserHotelRegistrationRequest>>());
        }

        [TestCase("asdasf123-adasd32")]
        public void Id_ShouldGetAndSetDataCorrectly(string testId)
        {
            var admin = new Admin { Id = testId };

            Assert.AreEqual(admin.Id, testId);
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
            var admin = new Admin { IsDeleted = testIsDeleted };

            Assert.AreEqual(admin.IsDeleted, testIsDeleted);
        }

        [TestCase("asd13asd-adwqe24")]
        [TestCase("yrty324g-234egfed")]
        public void UserProfile_ShouldGetAndSetDataCorrectly(string testUserId)
        {
            // Arrange & Act         
            var profile = new UserProfile { Id = testUserId };
            var admin = new Admin { UserProfile = profile };

            //Assert
            Assert.AreEqual(admin.UserProfile.Id, testUserId);
        }
    }
}
