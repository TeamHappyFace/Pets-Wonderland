using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Models.Tests.AnimalsTests
{
    [TestFixture]
    public class UserAnimalTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(UserAnimal).GetProperty("Id");

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
            var userAnimal = new UserAnimal { Id = testId };

            //Assert
            Assert.AreEqual(testId, userAnimal.Id);
        }

        [TestCase("a123asdf-asd323")]
        [TestCase("312wfds23-4345sdwf")]
        public void UserId_ShouldGetAndSetDataCorrectly(string testUserId)
        {
            // Arrange & Act
            var userAnimal = new UserAnimal { UserId = testUserId };

            //Assert
            Assert.AreEqual(userAnimal.UserId, testUserId);
        }

        [TestCase("Gosho")]
        [TestCase("Mosho")]
        public void User_ShouldGetAndSetDataCorrectly(string testFirstname)
        {
            // Arrange & Act         
            var user = new RegularUser() { FirstName = testFirstname };
            var userAnimal = new UserAnimal() { User = user };

            //Assert
            Assert.AreEqual(userAnimal.User.FirstName, testFirstname);
        }

        [TestCase(15)]
        [TestCase(20)]
        public void AnimalId_ShouldGetAndSetDataCorrectly(int testAnimalId)
        {
            // Arrange & Act
            var userAnimal = new UserAnimal() { AnimalId = testAnimalId };

            //Assert
            Assert.AreEqual(userAnimal.AnimalId, testAnimalId);
        }

        [TestCase("Doggy1")]
        [TestCase("Doggy2")]
        public void Animal_ShouldGetAndSetDataCorrectly(string testAnimalName)
        {
            // Arrange & Act         
            var animal = new Animal { Name = testAnimalName };
            var userAnimal = new UserAnimal() { Animal = animal };

            //Assert
            Assert.AreEqual(userAnimal.Animal.Name, testAnimalName);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var userAnimal = new UserAnimal() { IsDeleted = testIsDeleted };

            //Assert
            Assert.AreEqual(testIsDeleted, userAnimal.IsDeleted);
        }
    }
}
