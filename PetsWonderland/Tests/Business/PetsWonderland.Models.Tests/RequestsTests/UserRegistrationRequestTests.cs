using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Models.Tests.RequestsTests
{
    [TestFixture]
    public class UserRegistrationRequestTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(UserHotelRegistrationRequest).GetProperty("Id");

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
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { Id = testId };

            //Assert
            Assert.AreEqual(testId, userHotelRegistrationRequest.Id);
        }

        [TestCase("01/01/2017")]
        public void DateOfRequest_ShouldGetAndSetDataCorrectly(DateTime testDate)
        {
            // Arrange & Act
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { DateOfRequest = testDate };

            //Assert
            Assert.AreEqual(userHotelRegistrationRequest.DateOfRequest, testDate);
        }

        [TestCase("asd12asdwe3")]
        [TestCase("1dw3-asd234-gdfg2342")]
        public void HotelManagerId_ShouldGetAndSetDataCorrectly(string testManagerId)
        {
            // Arrange & Act
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { HotelManagerId = testManagerId };

            //Assert
            Assert.AreEqual(userHotelRegistrationRequest.HotelManagerId, testManagerId);
        }

        [TestCase("Pencho")]
        [TestCase("Mencho")]
        public void HotelManager_ShouldGetAndSetDataCorrectly(string testManagerFirstname)
        {
            // Arrange & Act         
            var manager = new HotelManager { FirstName = testManagerFirstname };
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { HotelManager = manager };

            //Assert
            Assert.AreEqual(userHotelRegistrationRequest.HotelManager.FirstName, testManagerFirstname);
        }

        [TestCase(123)]
        public void HotelId_ShouldGetAndSetDataCorrectly(int testHotelId)
        {
            // Arrange & Act
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { HotelId = testHotelId };

            //Assert
            Assert.AreEqual(userHotelRegistrationRequest.HotelId, testHotelId);
        }

        [TestCase("Doggies2")]
        [TestCase("Doggies3")]
        public void Hotel_ShouldGetAndSetDataCorrectly(string testHotelName)
        {
            // Arrange & Act         
            var hotel = new Hotel { Name = testHotelName };
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { Hotel = hotel };

            //Assert
            Assert.AreEqual(userHotelRegistrationRequest.Hotel.Name, testHotelName);
        }
           
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { IsDeleted = testIsDeleted };

            //Assert
            Assert.AreEqual(userHotelRegistrationRequest.IsDeleted, testIsDeleted);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsAccepted_ShouldGetAndSetDataCorrectly(bool testIsAccepted)
        {
            // Arrange & Act
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { IsAccepted = testIsAccepted };

            //Assert
            Assert.AreEqual(userHotelRegistrationRequest.IsAccepted, testIsAccepted);
        }
    }
}
