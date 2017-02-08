using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Models.Tests.HotelsTests
{
    [TestFixture]
    public class UserHotelTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(UserHotel).GetProperty("Id");

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
            var userHotel = new UserHotel() { Id = testId };

            //Assert
            Assert.AreEqual(testId, userHotel.Id);
        }

        [TestCase("asf33-23423fsd")]
        [TestCase("5sdfsdf34-sdf43")]
        public void HotelManagerId_ShouldGetAndSetDataCorrectly(string testManagerId)
        {
            // Arrange & Act
            var userHotel = new UserHotel { HotelManagerId = testManagerId };

            //Assert
            Assert.AreEqual(userHotel.HotelManagerId, testManagerId);
        }

        [TestCase("Pencho")]
        [TestCase("Mencho")]
        public void HotelManager_ShouldGetAndSetDataCorrectly(string testManagerFirstname)
        {
            // Arrange & Act         
            var manager = new HotelManager { FirstName = testManagerFirstname };
            var userHotel = new UserHotel { HotelManager = manager };

            //Assert
            Assert.AreEqual(userHotel.HotelManager.FirstName, testManagerFirstname);
        }

        [TestCase(123)]
        public void HotelId_ShouldGetAndSetDataCorrectly(int testHotelId)
        {
            // Arrange & Act
            var userHotel = new UserHotel { HotelId = testHotelId };

            //Assert
            Assert.AreEqual(userHotel.HotelId, testHotelId);
        }

        [TestCase("Doggies2")]
        [TestCase("Doggies3")]
        public void Hotel_ShouldGetAndSetDataCorrectly(string testHotelName)
        {
            // Arrange & Act         
            var hotel = new Hotel { Name = testHotelName };
            var userHotel = new UserHotel { Hotel = hotel };

            //Assert
            Assert.AreEqual(userHotel.Hotel.Name, testHotelName);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var userHotel = new UserHotel { IsDeleted = testIsDeleted };

            //Assert
            Assert.AreEqual(userHotel.IsDeleted, testIsDeleted);
        }
    }
}
