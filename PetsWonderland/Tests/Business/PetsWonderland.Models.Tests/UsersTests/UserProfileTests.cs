using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Models.Tests.UsersTests
{
    [TestFixture]
    public class UserProfileTests
    {
        [Test]
        public void FirstName_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var firstNameProperty = typeof(UserProfile).GetProperty("FirstName");

            // Act
            var minLengthAttribute = firstNameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMinLength));
        }

        [Test]
        public void FirstName_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var firstNameProperty = typeof(UserProfile).GetProperty("FirstName");

            // Act
            var maxLengthAttribute = firstNameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMaxLength));
        }

        [TestCase("Pesho")]
        [TestCase("Micho")]
        public void FirstName_ShouldGetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var userProfile = new UserProfile() { FirstName = testName };

            //Assert
            Assert.AreEqual(userProfile.FirstName, testName);
        }

        [Test]
        public void LastName_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var lastNameProperty = typeof(UserProfile).GetProperty("LastName");

            // Act
            var minLengthAttribute = lastNameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMinLength));
        }

        [Test]
        public void LastName_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var lastNameProperty = typeof(UserProfile).GetProperty("LastName");

            // Act
            var maxLengthAttribute = lastNameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMaxLength));
        }

        [TestCase("Ivanov")]
        [TestCase("Petrov")]
        public void LastName_ShouldGetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var userProfile = new UserProfile() { LastName = testName };

            //Assert
            Assert.AreEqual(userProfile.LastName, testName);
        }

        [TestCase(52)]
        [TestCase(22)]
        public void Age_ShouldGetAndSetDataCorrectly(int testAge)
        {
            // Arrange & Act
            var userProfile = new UserProfile() { Age = testAge };

            //Assert
            Assert.AreEqual(userProfile.Age, testAge);
        }

        [TestCase("/uploads/users/11/avata01.jpg")]
        [TestCase("/uploads/users/11/avata02.jpg")]
        public void HotelImageUrl_ShouldGetAndSetDataCorrectly(string testImagePath)
        {
            // Arrange & Act
            var userProfile = new UserProfile() { AvatarUrl = testImagePath };

            //Assert
            Assert.AreEqual(userProfile.AvatarUrl, testImagePath);
        }
        
               
    }
}
