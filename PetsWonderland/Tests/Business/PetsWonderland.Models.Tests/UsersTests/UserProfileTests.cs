using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Models.Tests.UsersTests
{
    [TestFixture]
    public class UserProfileTests
    {
        [Test]
        public void FirstName_ShouldHaveCorrectMinLength()
        {
            var firstNameProperty = typeof(UserProfile).GetProperty("FirstName");

            var minLengthAttribute = firstNameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMinLength));
        }

        [Test]
        public void FirstName_ShouldHaveCorrectMaxLength()
        {
            var firstNameProperty = typeof(UserProfile).GetProperty("FirstName");

            var maxLengthAttribute = firstNameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMaxLength));
        }

        [TestCase("Pesho")]
        [TestCase("Micho")]
        public void FirstName_ShouldGetAndSetDataCorrectly(string testName)
        {
            var userProfile = new UserProfile() { FirstName = testName };

            Assert.AreEqual(userProfile.FirstName, testName);
        }

        [Test]
        public void LastName_ShouldHaveCorrectMinLength()
        {
            var lastNameProperty = typeof(UserProfile).GetProperty("LastName");

            var minLengthAttribute = lastNameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMinLength));
        }

        [Test]
        public void LastName_ShouldHaveCorrectMaxLength()
        {
            var lastNameProperty = typeof(UserProfile).GetProperty("LastName");

            var maxLengthAttribute = lastNameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMaxLength));
        }

        [TestCase("Ivanov")]
        [TestCase("Petrov")]
        public void LastName_ShouldGetAndSetDataCorrectly(string testName)
        {
            var userProfile = new UserProfile() { LastName = testName };

            Assert.AreEqual(userProfile.LastName, testName);
        }

        [TestCase(52)]
        [TestCase(22)]
        public void Age_ShouldGetAndSetDataCorrectly(int testAge)
        {
            var userProfile = new UserProfile() { Age = testAge };

            Assert.AreEqual(userProfile.Age, testAge);
        }

        [TestCase("/uploads/users/11/avata01.jpg")]
        [TestCase("/uploads/users/11/avata02.jpg")]
        public void HotelImageUrl_ShouldGetAndSetDataCorrectly(string testImagePath)
        {
            var userProfile = new UserProfile() { AvatarUrl = testImagePath };

            Assert.AreEqual(userProfile.AvatarUrl, testImagePath);
        }       
    }
}
