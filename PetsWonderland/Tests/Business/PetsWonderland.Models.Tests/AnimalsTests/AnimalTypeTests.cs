using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Animals;

namespace PetsWonderland.Models.Tests.AnimalsTests
{
    [TestFixture]
    public class AnimalTypeModelTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            var idProperty = typeof(AnimalType).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            var animalType = new AnimalType { Id = testId };

            Assert.AreEqual(testId, animalType.Id);
        }

        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(AnimalType).GetProperty("Name");

            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Name_ShouldHaveCorrectMinLength()
        {
            var nameProperty = typeof(AnimalType).GetProperty("Name");

            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinTypeLength));
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            var nameProperty = typeof(AnimalType).GetProperty("Name");

            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxTypeLength));
        }

        [TestCase("Cat")]
        [TestCase("Dog")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            var animalType = new AnimalType { Name = testName };

            Assert.AreEqual(testName, animalType.Name);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            var animalType = new AnimalType { IsDeleted = testIsDeleted };

            Assert.AreEqual(testIsDeleted, animalType.IsDeleted);
        }
    }
}
