using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Models.Tests.HotelsTests
{
    [TestFixture]
    public class HotelLocationTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            var idProperty = typeof(HotelLocation).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            var hotelLocation = new HotelLocation() { Id = testId };

            Assert.AreEqual(hotelLocation.Id, testId);
        }

        [Test]
        public void Address_ShouldHaveRequiredAttribute()
        {
            var addressProperty = typeof(HotelLocation).GetProperty("Address");

            var requiredAttribute = addressProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }       
               
        [Test]
        public void Address_ShouldHaveCorrectMaxLength()
        {
            var addressProperty = typeof(HotelLocation).GetProperty("Address");

            var maxLengthAttribute = addressProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxAddressDescription));
        }

        [TestCase("Sofia")]
        [TestCase("Plovdiv")]
        public void Address_ShouldGetAndSetDataCorrectly(string testAddress)
        {
            var location = new HotelLocation() { Address = testAddress };

            Assert.AreEqual(location.Address, testAddress);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            var hotel = new HotelLocation() { IsDeleted = testIsDeleted };

            Assert.AreEqual(hotel.IsDeleted, testIsDeleted);
        }
    }
}
