﻿using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Models.Tests.UsersTests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var user = new RegularUser();

            // Assert
            Assert.IsInstanceOf<RegularUser>(user);
        }      

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var user = new RegularUser { IsDeleted = testIsDeleted };

            //Assert
            Assert.AreEqual(user.IsDeleted, testIsDeleted);
        }

        [TestCase("asd13asd-adwqe24")]
        [TestCase("yrty324g-234egfed")]
        public void UserProfile_ShouldGetAndSetDataCorrectly(string testUserId)
        {
            // Arrange & Act         
            var profile = new UserProfile { Id = testUserId };
            var regularUser = new RegularUser { UserProfile = profile };

            //Assert
            Assert.AreEqual(regularUser.UserProfile.Id, testUserId);
        }
    }
}
