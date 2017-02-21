using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
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
            var idProperty = typeof(UserHotelRegistrationRequest).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { Id = testId };

            Assert.AreEqual(testId, userHotelRegistrationRequest.Id);
        }

        [TestCase("01/01/2017")]
        public void DateOfRequest_ShouldGetAndSetDataCorrectly(DateTime testDate)
        {
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { DateOfRequest = testDate };

            Assert.AreEqual(userHotelRegistrationRequest.DateOfRequest, testDate);
        }

        [TestCase("asd12asdwe3")]
        [TestCase("1dw3-asd234-gdfg2342")]
        public void HotelManagerId_ShouldGetAndSetDataCorrectly(string testManagerId)
        {
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { HotelManagerId = testManagerId };

            Assert.AreEqual(userHotelRegistrationRequest.HotelManagerId, testManagerId);
        }

        [TestCase("rhf43232-dfge-sfedr43-afdf")]
        [TestCase("asdas23r54r-123ewf")]
        public void HotelManager_ShouldGetAndSetDataCorrectly(string testManagerId)
        {         
            var manager = new HotelManager { Id = testManagerId };
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { HotelManager = manager };

            Assert.AreEqual(userHotelRegistrationRequest.HotelManager.Id, testManagerId);
        }
           
        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { IsDeleted = testIsDeleted };

            Assert.AreEqual(userHotelRegistrationRequest.IsDeleted, testIsDeleted);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsAccepted_ShouldGetAndSetDataCorrectly(bool testIsAccepted)
        {
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { IsAccepted = testIsAccepted };

            Assert.AreEqual(userHotelRegistrationRequest.IsAccepted, testIsAccepted);
        }

        [TestCase("Marmalade")]
        [TestCase("ChockoPie4")]
        public void HotelName_ShouldGetAndSetDataCorrectly(string name)
        {
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { HotelName = name };

            Assert.AreEqual(userHotelRegistrationRequest.HotelName, name);
        }

        [TestCase("loc1")]
        [TestCase("location2")]
        public void HotelLocation_ShouldGetAndSetDataCorrectly(string locationName)
        {
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { HotelLocation = locationName };

            Assert.AreEqual(userHotelRegistrationRequest.HotelLocation, locationName);
        }

        [TestCase("Lotem ipsul dolro sit amet")]
        public void HotelDescription_ShouldGetAndSetDataCorrectly(string description)
        {
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { HotelDescription = description };

            Assert.AreEqual(userHotelRegistrationRequest.HotelDescription, description);
        }

        [TestCase("/images/uploads/hotels/1.jpg")]
        [TestCase("/images/uploads/hotels/12.jpg")]
        public void HotelDImageUrl_ShouldGetAndSetDataCorrectly(string url)
        {
            var userHotelRegistrationRequest = new UserHotelRegistrationRequest { HotelImageUrl = url };

            Assert.AreEqual(userHotelRegistrationRequest.HotelImageUrl, url);
        }
    }
}
