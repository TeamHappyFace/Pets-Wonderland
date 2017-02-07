using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Models.Tests.HotelsTests
{
    [TestFixture]
    public class HotelLocationTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(HotelLocation).GetProperty("Id");

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
            var hotelLocation = new HotelLocation() { Id = testId };

            //Assert
            Assert.AreEqual(hotelLocation.Id, testId);
        }

        [Test]
        public void Address_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var addressProperty = typeof(HotelLocation).GetProperty("Address");

            // Act
            var requiredAttribute = addressProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }       

        [Test]
        public void Address_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var addressProperty = typeof(HotelLocation).GetProperty("Address");

            // Act
            var minLengthAttribute = addressProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinAddressDescription));
        }

        [Test]
        public void Address_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var addressProperty = typeof(HotelLocation).GetProperty("Address");

            // Act
            var maxLengthAttribute = addressProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxAddressDescription));
        }

        [TestCase("Sofia")]
        [TestCase("Plovdiv")]
        public void Address_ShouldGetAndSetDataCorrectly(string testAddress)
        {
            // Arrange & Act
            var location = new HotelLocation() { Address = testAddress };

            //Assert
            Assert.AreEqual(location.Address, testAddress);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var hotel = new HotelLocation() { IsDeleted = testIsDeleted };

            //Assert
            Assert.AreEqual(hotel.IsDeleted, testIsDeleted);
        }
    }
}
