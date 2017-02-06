using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;

using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Common.Constants;

namespace PetsWonderland.Models.Tests.AnimalTests
{
    [TestFixture]
    public class AnimalModelTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(Animal).GetProperty("Id");

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
            var animal = new Animal { Id = testId };

            //Assert
            Assert.AreEqual(testId, animal.Id);
        }

        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(Animal).GetProperty("Name");
            
            // Act
            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }
     
        [Test]
        public void Name_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(Animal).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMinLength));
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Animal).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();
          
            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMaxLength));
        }

        [TestCase("Pencho")]
        [TestCase("Gosho")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var animal = new Animal {Name = testName};

            //Assert
            Assert.AreEqual(testName, animal.Name);
        }

        [Test]
        public void Age_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var ageProperty = typeof(Animal).GetProperty("Age");

            // Act
            var requiredAttribute = ageProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(20)]
        [TestCase(30)]
        public void Age_ShouldGetAndSetDataCorrectly(int testAge)
        {
            // Arrange & Act
            var animal = new Animal { Age = testAge };

            //Assert
            Assert.AreEqual(testAge, animal.Age);
        }

        [TestCase("/uploads/users/11/avata01.jpg")]
        [TestCase("/uploads/users/11/avata02.jpg")]  
        public void AvatarUrl_ShouldGetAndSetDataCorrectly(string testAvatarPath)
        {
            // Arrange & Act
            var animal = new Animal { AvatarUrl = testAvatarPath };

            //Assert
            Assert.AreEqual(testAvatarPath, animal.AvatarUrl);
        }

        [Test]
        public void Description_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var descriptionProperty = typeof(Animal).GetProperty("Description");

            // Act
            var minLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinAnimalDescription));
        }

        [Test]
        public void Description_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var descriptionProperty = typeof(Animal).GetProperty("Description");

            // Act
            var maxLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxAnimalDescription));
        }

        [TestCase("Lorem ipsum dolor sit amet")]
        public void Description_ShouldGetAndSetDataCorrectly(string testDescription)
        {
            // Arrange & Act
            var animal = new Animal { Description = testDescription };

            //Assert
            Assert.AreEqual(testDescription, animal.Description);
        }

        [TestCase(15)]
        [TestCase(20)]
        public void AnimalTypeId_ShouldGetAndSetDataCorrectly(int testAnimalTypeId)
        {
            // Arrange & Act
            var animal = new Animal { AnimalTypeId = testAnimalTypeId };

            //Assert
            Assert.AreEqual(testAnimalTypeId, animal.AnimalTypeId);
        }

        [TestCase("Cat")]
        [TestCase("Dog")]
        public void AnimalType_ShouldGetAndSetDataCorrectly(string testAnimalTypeName)
        {        
            // Arrange & Act         
            var animalType = new AnimalType { Name = testAnimalTypeName };
            var animal = new Animal { AnimalType = animalType };           

            //Assert
            Assert.AreEqual(animal.AnimalType.Name, testAnimalTypeName);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var animal = new Animal { IsDeleted = testIsDeleted };

            //Assert
            Assert.AreEqual(testIsDeleted, animal.IsDeleted);
        }
    }
}
