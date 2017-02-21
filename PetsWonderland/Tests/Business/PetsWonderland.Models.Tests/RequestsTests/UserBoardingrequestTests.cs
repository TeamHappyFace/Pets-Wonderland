using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
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
            var idProperty = typeof(UserBoardingRequest).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {   
            var userHotel = new UserBoardingRequest { Id = testId };

            Assert.AreEqual(testId, userHotel.Id);
        }

        [TestCase("Marmalade")]
        [TestCase("ChockoPie4")]
        public void PetName_ShouldGetAndSetDataCorrectly(string name)
        {
            var boardingRequest = new UserBoardingRequest { PetName = name };

            Assert.AreEqual(boardingRequest.PetName, name);
        }

        [TestCase("Doberman")]
        [TestCase("Pitbull")]
        public void PetBreed_ShouldGetAndSetDataCorrectly(string breed)
        {
            var boardingRequest = new UserBoardingRequest { PetBreed = breed };

            Assert.AreEqual(boardingRequest.PetBreed, breed);
        }

        [TestCase("/uploads/images/1.png")]
        [TestCase("/uploads/images/512.jpg")]       
        public void ImageUrl_ShouldGetAndSetDataCorrectly(string imageUrl)
        {
            var boardingRequest = new UserBoardingRequest { ImageUrl = imageUrl };

            Assert.AreEqual(boardingRequest.ImageUrl, imageUrl);
        }

        [TestCase("01/01/2017")]
        public void FromDate_ShouldGetAndSetDataCorrectly(string testDate)
        {
            var userBoardingRequest = new UserBoardingRequest { FromDate = testDate };

            Assert.AreEqual(userBoardingRequest.FromDate, testDate);
        }

        [TestCase("01/01/2017")]
        public void ToDate_ShouldGetAndSetDataCorrectly(string testDate)
        {
            var userBoardingRequest = new UserBoardingRequest { ToDate = testDate };

            Assert.AreEqual(userBoardingRequest.ToDate, testDate);
        }

        [TestCase("01/01/2017")]
        public void DateOfRequest_ShouldGetAndSetDataCorrectly(DateTime testDate)
        {
            var userBoardingRequest = new UserBoardingRequest { DateOfRequest = testDate };

            Assert.AreEqual(userBoardingRequest.DateOfRequest, testDate);
        }

        [TestCase(18)]
        [TestCase(22)]
        public void Age_ShouldGetAndSetDataCorrectly(int age)
        {
            var userBoardingRequest = new UserBoardingRequest { Age = age };

            Assert.AreEqual(userBoardingRequest.Age, age);
        }

        [TestCase("asd12asdwe3")]
        [TestCase("1dw3-asd234-gdfg2342")]
        public void UserId_ShouldGetAndSetDataCorrectly(string testUserId)
        {
            var userBoardingRequest = new UserBoardingRequest { UserId = testUserId };

            Assert.AreEqual(userBoardingRequest.UserId, testUserId);
        }

        [TestCase("hrt42dfg-sdfgdgt234e")]
        [TestCase("dfsdf234-4-sdfsf")]
        public void User_ShouldGetAndSetDataCorrectly(string testUserId)
        {         
            var user = new RegularUser { Id = testUserId };
            var userBoardingRequest = new UserBoardingRequest { User = user };

            Assert.AreEqual(userBoardingRequest.User.Id, testUserId);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            var userBoardingRequest = new UserBoardingRequest { IsDeleted = testIsDeleted };

            Assert.AreEqual(userBoardingRequest.IsDeleted, testIsDeleted);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsAccepted_ShouldGetAndSetDataCorrectly(bool testIsAccepted)
        {
            var userBoardingRequest = new UserBoardingRequest { IsAccepted = testIsAccepted };

            Assert.AreEqual(userBoardingRequest.IsAccepted, testIsAccepted);
        }

        [TestCase("asd12asdwe3")]
        [TestCase("1dw3-asd234-gdfg2342")]
        public void HotelManagerId_ShouldGetAndSetDataCorrectly(string testManagerId)
        {
            var userBoardingRequest = new UserBoardingRequest { HotelManagerId = testManagerId };

            Assert.AreEqual(userBoardingRequest.HotelManagerId, testManagerId);
        }

        [TestCase("rhf43232-dfge-sfedr43-afdf")]
        [TestCase("asdas23r54r-123ewf")]
        public void HotelManager_ShouldGetAndSetDataCorrectly(string testManagerId)
        {
            var manager = new HotelManager { Id = testManagerId };
            var userBoardingRequest = new UserBoardingRequest { HotelManager = manager };

            Assert.AreEqual(userBoardingRequest.HotelManager.Id, testManagerId);
        }
    }
}
