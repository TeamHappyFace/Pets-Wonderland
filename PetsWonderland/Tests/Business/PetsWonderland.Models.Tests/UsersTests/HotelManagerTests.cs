using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Models.Tests.UsersTests
{
    [TestFixture]
    public class HotelManagerTests
    {
        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var manager = new HotelManager();

            // Assert
            Assert.IsInstanceOf<HotelManager>(manager);
        }

        [Test]
        public void Constructor_ShouldInitializeBoardingRequestsCollectionCorrectly()
        {
            var manager = new HotelManager();

            var boardingRequests = manager.UserBoardingRequests;

            Assert.That(boardingRequests, Is.Not.Null.And.InstanceOf<HashSet<UserBoardingRequest>>());
        }

        [Test]
        public void Constructor_ShouldInitializeHotelsCollectionCorrectly()
        {
            var manager = new HotelManager();

            var hotels = manager.Hotels;

            Assert.That(hotels, Is.Not.Null.And.InstanceOf<HashSet<Hotel>>());
        }

        [TestCase(123)]
        [TestCase(12)]
        public void BoardingRequestCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            var boardingRequest = new UserBoardingRequest() { Id = testId };
            var set = new HashSet<UserBoardingRequest> { boardingRequest };

            var manager = new HotelManager { UserBoardingRequests = set };

            Assert.AreEqual(manager.UserBoardingRequests.First().Id, testId);
        }

        [TestCase(123)]
        [TestCase(12)]
        public void HotelsCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            var hotel = new Hotel { Id = testId };
            var set = new HashSet<Hotel> { hotel };

            var manager = new HotelManager { Hotels = set };

            Assert.AreEqual(manager.Hotels.First().Id, testId);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var manager = new HotelManager { IsDeleted = testIsDeleted };

            //Assert
            Assert.AreEqual(manager.IsDeleted, testIsDeleted);
        }

        [TestCase("asd13asd-adwqe24")]
        [TestCase("yrty324g-234egfed")]
        public void UserProfile_ShouldGetAndSetDataCorrectly(string testUserId)
        {
            // Arrange & Act         
            var profile = new UserProfile { Id = testUserId };
            var manager = new HotelManager { UserProfile = profile };

            //Assert
            Assert.AreEqual(manager.UserProfile.Id, testUserId);
        }
    }
}
