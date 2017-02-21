using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using PetsWonderland.Business.Models.Pages;

namespace PetsWonderland.Models.Tests.PagesTests
{
    [TestFixture]
    public class SliderTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            var idProperty = typeof(Slider).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            var slider = new Slider { Id = testId };

            Assert.AreEqual(testId, slider.Id);
        }

        [TestCase("Test Petswonderland")]
        public void Name_ShouldGetAndSetDataCorrectly(string name)
        {
            var slider = new Slider { Name = name };

            Assert.AreEqual(slider.Name, name);
        }

        [TestCase("homepage")]
        [TestCase("contacts")]
        public void Position_ShouldGetAndSetDataCorrectly(string position)
        {
            var slider = new Slider { Position = position };

            Assert.AreEqual(slider.Position, position);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldGetAndSetDataCorrectly(bool testIsDeleted)
        {
            var slider = new Slider { IsDeleted = testIsDeleted };

            Assert.AreEqual(slider.IsDeleted, testIsDeleted);
        }

        [Test]
        public void Constructor_ShouldInitializeSlidesCollectionCorrectly()
        {
            var slider = new Slider();

            var slides = slider.Slides;

            Assert.That(slides, Is.Not.Null.And.InstanceOf<HashSet<Slide>>());
        }

        [TestCase(123)]
        [TestCase(12)]
        public void SlidesCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            var slide = new Slide { Id = testId };
            var set = new HashSet<Slide> { slide };

            var slider = new Slider { Slides = set };

            Assert.AreEqual(slider.Slides.Count, 1);
        }
    }    
}
