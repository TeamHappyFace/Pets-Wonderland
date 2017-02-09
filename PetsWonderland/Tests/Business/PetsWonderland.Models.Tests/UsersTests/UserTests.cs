using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Requests;
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

        [Test]
        public void Constructor_ShouldInitializeAnimalsCollectionCorrectly()
        {
            var user = new RegularUser();

            var animals = user.Animals;

            Assert.That(animals, Is.Not.Null.And.InstanceOf<HashSet<UserAnimal>>());
        }

        [TestCase(123)]
        [TestCase(6)]
        public void AnimalsCollection_ShouldGetAndSetDataCorrectly(int userAnimalId)
        {
            var animal = new UserAnimal() { Id = userAnimalId };
            var set = new HashSet<UserAnimal> { animal };

            var user = new RegularUser { Animals = set };

            Assert.AreEqual(user.Animals.First().Id, userAnimalId);
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
    }
}
