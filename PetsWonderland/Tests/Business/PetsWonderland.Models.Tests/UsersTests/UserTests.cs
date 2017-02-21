using System.Collections.Generic;
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
            var user = new RegularUser();

            Assert.IsInstanceOf<RegularUser>(user);
        }      

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            var user = new RegularUser { IsDeleted = testIsDeleted };

            Assert.AreEqual(user.IsDeleted, testIsDeleted);
        }

        [TestCase("asd13asd-adwqe24")]
        [TestCase("yrty324g-234egfed")]
        public void UserProfile_ShouldGetAndSetDataCorrectly(string testUserId)
        {      
            var profile = new UserProfile { Id = testUserId };
            var regularUser = new RegularUser { UserProfile = profile };

            Assert.AreEqual(regularUser.UserProfile.Id, testUserId);
        }

        [Test]
        public void Constructor_ShouldInitializeAnimalsCollectionCorrectly()
        {
            var admin = new RegularUser();

            var animals = admin.Animals;

            Assert.That(animals, Is.Not.Null.And.InstanceOf<HashSet<Animal>>());
        }

        [TestCase(123)]
        [TestCase(12)]
        public void AnimalsCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            var animal = new Animal { Id = testId };
            var set = new HashSet<Animal> { animal };

            var admin = new RegularUser { Animals = set };

            Assert.AreEqual(admin.Animals.Count, 1);
        }
    }
}
