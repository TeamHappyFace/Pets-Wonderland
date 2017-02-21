using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Animals;

namespace PetsWonderland.Models.Tests.AnimalsTests
{
    [TestFixture]
    public class AnimalTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            var idProperty = typeof(Animal).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            var animal = new Animal { Id = testId };

            Assert.AreEqual(testId, animal.Id);
        }

        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            var nameProperty = typeof(Animal).GetProperty("Name");
            
            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }
     
        [Test]
        public void Name_ShouldHaveCorrectMinLength()
        {
            var nameProperty = typeof(Animal).GetProperty("Name");

            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMinLength));
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            var nameProperty = typeof(Animal).GetProperty("Name");

            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();
          
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.NameMaxLength));
        }

        [TestCase("Pencho")]
        [TestCase("Gosho")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            var animal = new Animal { Name = testName };

            Assert.AreEqual(testName, animal.Name);
        }

        [Test]
        public void Age_ShouldHaveRequiredAttribute()
        {
            var ageProperty = typeof(Animal).GetProperty("Age");

            var requiredAttribute = ageProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(20)]
        [TestCase(30)]
        public void Age_ShouldGetAndSetDataCorrectly(int testAge)
        {
            var animal = new Animal { Age = testAge };

            Assert.AreEqual(testAge, animal.Age);
        }

        [TestCase("/uploads/users/11/avata01.jpg")]
        [TestCase("/uploads/users/11/avata02.jpg")]  
        public void AvatarUrl_ShouldGetAndSetDataCorrectly(string testAvatarPath)
        {
            var animal = new Animal { AvatarUrl = testAvatarPath };

            Assert.AreEqual(testAvatarPath, animal.AvatarUrl);
        }

        [Test]
        public void Description_ShouldHaveCorrectMinLength()
        {
            var descriptionProperty = typeof(Animal).GetProperty("Description");

            var minLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MinAnimalDescription));
        }

        [Test]
        public void Description_ShouldHaveCorrectMaxLength()
        {
            var descriptionProperty = typeof(Animal).GetProperty("Description");

            var maxLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ValidationConstants.MaxAnimalDescription));
        }

        [TestCase("Lorem ipsum dolor sit amet")]
        public void Description_ShouldGetAndSetDataCorrectly(string testDescription)
        {
            var animal = new Animal { Description = testDescription };

            Assert.AreEqual(testDescription, animal.Description);
        }

        [TestCase(15)]
        [TestCase(20)]
        public void AnimalTypeId_ShouldGetAndSetDataCorrectly(int testAnimalTypeId)
        {
            var animal = new Animal { AnimalTypeId = testAnimalTypeId };

            Assert.AreEqual(testAnimalTypeId, animal.AnimalTypeId);
        }

        [TestCase("Cat")]
        [TestCase("Dog")]
        public void AnimalType_ShouldGetAndSetDataCorrectly(string testAnimalTypeName)
        {              
            var animalType = new AnimalType { Name = testAnimalTypeName };
            var animal = new Animal { AnimalType = animalType };           
 
            Assert.AreEqual(animal.AnimalType.Name, testAnimalTypeName);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            var animal = new Animal { IsDeleted = testIsDeleted };

            Assert.AreEqual(testIsDeleted, animal.IsDeleted);
        }
    }
}
