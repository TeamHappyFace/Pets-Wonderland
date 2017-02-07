using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Models.Tests.AnimalsTests
{
    [TestFixture]
    public class HotelAnimalTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(HotelAnimal).GetProperty("Id");

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
            var hotelAnimal = new HotelAnimal { Id = testId };

            //Assert
            Assert.AreEqual(testId, hotelAnimal.Id);
        }

        [TestCase(15)]
        [TestCase(20)]
        public void HotelId_ShouldGetAndSetDataCorrectly(int testHotelId)
        {
            // Arrange & Act
            var hotelAnimal = new HotelAnimal { HotelId = testHotelId };

            //Assert
            Assert.AreEqual(testHotelId, hotelAnimal.HotelId);
        }

        [TestCase("CatsWonderland")]
        [TestCase("DogsWonderland")]
        public void Hotel_ShouldGetAndSetDataCorrectly(string testHotelName)
        {
            // Arrange & Act         
            var hotel = new Hotel { Name = testHotelName };
            var hotelAnimal = new HotelAnimal() { Hotel = hotel };

            //Assert
            Assert.AreEqual(hotelAnimal.Hotel.Name, testHotelName);
        }

        [TestCase(15)]
        [TestCase(20)]
        public void AnimalId_ShouldGetAndSetDataCorrectly(int testAnimalId)
        {
            // Arrange & Act
            var hotelAnimal = new HotelAnimal { AnimalId = testAnimalId };

            //Assert
            Assert.AreEqual(hotelAnimal.AnimalId, testAnimalId);
        }

        [TestCase("Doggy1")]
        [TestCase("Doggy2")]
        public void Animal_ShouldGetAndSetDataCorrectly(string testAnimalName)
        {
            // Arrange & Act         
            var animal = new Animal { Name = testAnimalName };
            var hotelAnimal = new HotelAnimal() { Animal = animal };

            //Assert
            Assert.AreEqual(hotelAnimal.Animal.Name, testAnimalName);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var hotelAnimal = new HotelAnimal() { IsDeleted = testIsDeleted };

            //Assert
            Assert.AreEqual(testIsDeleted, hotelAnimal.IsDeleted);
        }
    }
}
