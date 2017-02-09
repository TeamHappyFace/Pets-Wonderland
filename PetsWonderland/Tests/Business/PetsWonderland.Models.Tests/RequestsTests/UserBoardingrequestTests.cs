using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Models.Tests.RequestsTests
{
    [TestFixture]
    public class UserBoardingrequestTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(UserBoardingRequest).GetProperty("Id");

            // Act
            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            // Arrange & Act
            var userHotel = new UserBoardingRequest { Id = testId };

            //Assert
            Assert.AreEqual(testId, userHotel.Id);
        }

        [TestCase("01/01/2017")]
        public void DateOfRequest_ShouldGetAndSetDataCorrectly(DateTime testDate)
        {
            // Arrange & Act
            var userBoardingRequest = new UserBoardingRequest { DateOfRequest = testDate };

            //Assert
            Assert.AreEqual(userBoardingRequest.DateOfRequest, testDate);
        }

        [TestCase("asd12asdwe3")]
        [TestCase("1dw3-asd234-gdfg2342")]
        public void UserId_ShouldGetAndSetDataCorrectly(string testUserId)
        {
            // Arrange & Act
            var userBoardingRequest = new UserBoardingRequest { UserId = testUserId };

            //Assert
            Assert.AreEqual(userBoardingRequest.UserId, testUserId);
        }

        [TestCase("Pencho")]
        [TestCase("Mencho")]
        public void User_ShouldGetAndSetDataCorrectly(string testUserFirstname)
        {
            // Arrange & Act         
            var user = new RegularUser { FirstName = testUserFirstname };
            var userBoardingRequest = new UserBoardingRequest { User = user };

            //Assert
            Assert.AreEqual(userBoardingRequest.User.FirstName, testUserFirstname);
        }

        [TestCase(123)]
        public void HotelId_ShouldGetAndSetDataCorrectly(int testHotelId)
        {
            // Arrange & Act
            var userBoardingRequest = new UserBoardingRequest { HotelId = testHotelId };

            //Assert
            Assert.AreEqual(userBoardingRequest.HotelId, testHotelId);
        }

        [TestCase("Doggies2")]
        [TestCase("Doggies3")]
        public void Hotel_ShouldGetAndSetDataCorrectly(string testHotelName)
        {
            // Arrange & Act         
            var hotel = new Hotel { Name = testHotelName };
            var userBoardingRequest = new UserBoardingRequest { Hotel = hotel };

            //Assert
            Assert.AreEqual(userBoardingRequest.Hotel.Name, testHotelName);
        }

        [TestCase(123)]
        [TestCase(323)]
        public void UserAnimalId_ShouldGetAndSetDataCorrectly(int testAnimalId)
        {
            // Arrange & Act
            var userBoardingRequest = new UserBoardingRequest { UserAnimalId = testAnimalId };

            //Assert
            Assert.AreEqual(userBoardingRequest.UserAnimalId, testAnimalId);
        }

        [TestCase(123)]
        [TestCase(3545323)]
        public void UserAnimal_ShouldGetAndSetDataCorrectly(int testAnimalId)
        {
            // Arrange & Act         
            var animal = new UserAnimal { AnimalId = testAnimalId };
            var userBoardingRequest = new UserBoardingRequest { UserAnimal = animal };

            //Assert
            Assert.AreEqual(userBoardingRequest.UserAnimal.AnimalId, testAnimalId);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var userBoardingRequest = new UserBoardingRequest { IsDeleted = testIsDeleted };

            //Assert
            Assert.AreEqual(userBoardingRequest.IsDeleted, testIsDeleted);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsAccepted_ShouldGetAndSetDataCorrectly(bool testIsAccepted)
        {
            // Arrange & Act
            var userBoardingRequest = new UserBoardingRequest { IsAccepted = testIsAccepted };

            //Assert
            Assert.AreEqual(userBoardingRequest.IsAccepted, testIsAccepted);
        }
    }
}
