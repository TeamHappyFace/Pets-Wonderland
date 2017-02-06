using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;

using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Common.Constants;

namespace PetsWonderland.Models.Tests.AnimalTests
{
    [TestFixture]
    public class AnimalTypeModelTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(AnimalType).GetProperty("Id");

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
            var animalType = new AnimalType { Id = testId };

            //Assert
            Assert.AreEqual(testId, animalType.Id);
        }

        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(AnimalType).GetProperty("Name");

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
            var nameProperty = typeof(AnimalType).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinTypeLength));
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(AnimalType).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxTypeLength));
        }

        [TestCase("Cat")]
        [TestCase("Dog")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var animalType = new AnimalType { Name = testName };

            //Assert
            Assert.AreEqual(testName, animalType.Name);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var animalType = new AnimalType { IsDeleted = testIsDeleted };

            //Assert
            Assert.AreEqual(testIsDeleted, animalType.IsDeleted);
        }
    }
}
