using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Models.Tests.HotelsTests
{
    [TestFixture]
    public class HotelTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(Hotel).GetProperty("Id");

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
            var userAnimal = new Hotel { Id = testId };

            //Assert
            Assert.AreEqual(testId, userAnimal.Id);
        }

        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(Hotel).GetProperty("Name");

            // Act
            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Name_ShouldHaveUniqueAttribute()
        {
            // Arrange
            var nameProperty = typeof(Hotel).GetProperty("Name");

            // Act
            var indexAttribute = nameProperty.GetCustomAttributes(typeof(IndexAttribute), true)
                .Cast<IndexAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(indexAttribute.IsUnique, Is.True);
        }

        [Test]
        public void Name_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(Hotel).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinHotelLength));
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Hotel).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxHotelLength));
        }

        [TestCase("CatsWonderland")]
        [TestCase("DogsWonderland")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var hotel = new Hotel { Name = testName };

            //Assert
            Assert.AreEqual(hotel.Name, testName);
        }

        [TestCase("/uploads/users/11/avata01.jpg")]
        [TestCase("/uploads/users/11/avata02.jpg")]
        public void HotelImageUrl_ShouldGetAndSetDataCorrectly(string testImagePath)
        {
            // Arrange & Act
            var hotel = new Hotel { ImageUrl = testImagePath };

            //Assert
            Assert.AreEqual(hotel.ImageUrl, testImagePath);
        }

        [Test]
        public void Description_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var descriptionProperty = typeof(Hotel).GetProperty("Description");

            // Act
            var maxLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxHotelDescription));
        }

        [TestCase("Lorem ipsum dolor sit amet")]     
        public void Description_ShouldGetAndSetDataCorrectly(string testDescription)
        {
            // Arrange & Act
            var hotel = new Hotel { Description = testDescription };

            //Assert
            Assert.AreEqual(hotel.Description, testDescription);
        }

        [TestCase(15)]
        [TestCase(20)]
        public void LocationId_ShouldGetAndSetDataCorrectly(int testLocationId)
        {
            // Arrange & Act
            var hotel = new Hotel { LocationId = testLocationId };

            //Assert
            Assert.AreEqual(hotel.LocationId, testLocationId);
        }

        [TestCase("Sofia")]
        [TestCase("Plovdiv")]
        public void Location_ShouldGetAndSetDataCorrectly(string testLocationAddress)
        {
            // Arrange & Act         
            var location = new HotelLocation() { Address = testLocationAddress };
            var hotel = new Hotel { Location = location };

            //Assert
            Assert.AreEqual(hotel.Location.Address, testLocationAddress);
        }


        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var hotel = new Hotel { IsDeleted = testIsDeleted };

            //Assert
            Assert.AreEqual(hotel.IsDeleted, testIsDeleted);
        }
    }
}
