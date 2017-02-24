using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Models.Tests.HotelsTests
{
    [TestFixture]
    public class HotelTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            var idProperty = typeof(Hotel).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            var userAnimal = new Hotel { Id = testId };

            Assert.AreEqual(testId, userAnimal.Id);
        }

        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(Hotel).GetProperty("Name");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Name_ShouldHaveUniqueAttribute()
        {
            var nameProperty = typeof(Hotel).GetProperty("Name");

            var indexAttribute = nameProperty.GetCustomAttributes(typeof(IndexAttribute), true)
                .Cast<IndexAttribute>()
                .FirstOrDefault();

            Assert.That(indexAttribute.IsUnique, Is.True);
        }

        [Test]
        public void Name_ShouldHaveCorrectMinLength()
        {
            var nameProperty = typeof(Hotel).GetProperty("Name");

            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinHotelLength));
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            var nameProperty = typeof(Hotel).GetProperty("Name");

            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxHotelLength));
        }

        [TestCase("CatsWonderland")]
        [TestCase("DogsWonderland")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            var hotel = new Hotel { Name = testName };

            Assert.AreEqual(hotel.Name, testName);
        }

        [TestCase("/uploads/users/11/avata01.jpg")]
        [TestCase("/uploads/users/11/avata02.jpg")]
        public void HotelImageUrl_ShouldGetAndSetDataCorrectly(string testImagePath)
        {
            var hotel = new Hotel { ImageUrl = testImagePath };

            Assert.AreEqual(hotel.ImageUrl, testImagePath);
        }

        //[Test]
        //public void Description_ShouldHaveCorrectMaxLength()
        //{
        //    var descriptionProperty = typeof(Hotel).GetProperty("Description");

        //    var maxLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
        //        .Cast<MaxLengthAttribute>()
        //        .FirstOrDefault();

        //    Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxHotelDescription));
        //}

        [TestCase("Lorem ipsum dolor sit amet")]     
        public void Description_ShouldGetAndSetDataCorrectly(string testDescription)
        {
            var hotel = new Hotel { Description = testDescription };

            Assert.AreEqual(hotel.Description, testDescription);
        }

        [TestCase(15)]
        [TestCase(20)]
        public void LocationId_ShouldGetAndSetDataCorrectly(int testLocationId)
        {
            var hotel = new Hotel { LocationId = testLocationId };

            Assert.AreEqual(hotel.LocationId, testLocationId);
        }

        [TestCase("Sofia")]
        [TestCase("Plovdiv")]
        public void Location_ShouldGetAndSetDataCorrectly(string testLocationAddress)
        {      
            var location = new HotelLocation() { Address = testLocationAddress };
            var hotel = new Hotel { Location = location };

            Assert.AreEqual(hotel.Location.Address, testLocationAddress);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            var hotel = new Hotel { IsDeleted = testIsDeleted };

            Assert.AreEqual(hotel.IsDeleted, testIsDeleted);
        }

        [TestCase("asd12asdwe3")]
        [TestCase("1dw3-asd234-gdfg2342")]
        public void HotelManagerId_ShouldGetAndSetDataCorrectly(string testUserId)
        {
            var hotel = new Hotel { HotelManagerId = testUserId };

            Assert.AreEqual(hotel.HotelManagerId, testUserId);
        }

        [TestCase("hrt42dfg-sdfgdgt234e")]
        [TestCase("dfsdf234-4-sdfsf")]
        public void HotelManager_ShouldGetAndSetDataCorrectly(string testUserId)
        {       
            var manager = new HotelManager { Id = testUserId };
            var hotel = new Hotel { HotelManager = manager };

            Assert.AreEqual(hotel.HotelManager.Id, testUserId);
        }
    }
}
