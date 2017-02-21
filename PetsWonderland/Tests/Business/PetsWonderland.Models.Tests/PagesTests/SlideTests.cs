using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Pages;

namespace PetsWonderland.Models.Tests.PagesTests
{
    [TestFixture]
    public class SlideTests
    {
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            var idProperty = typeof(Slide).GetProperty("Id");

            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            var slide = new Slide { Id = testId };

            Assert.AreEqual(testId, slide.Id);
        }

        [TestCase("Test Petswonderland")]
        public void Title_ShouldGetAndSetDataCorrectly(string title)
        {
            var slide = new Slide { Title = title };

            Assert.AreEqual(slide.Title, title);
        }

        [TestCase("Marmalade")]
        [TestCase("ChockoPie4")]
        public void Caption_ShouldGetAndSetDataCorrectly(string caption)
        {
            var slide = new Slide { Caption = caption };

            Assert.AreEqual(slide.Caption, caption);
        }

        [TestCase("/uploads/slider/01.png")] 
        public void Image_ShouldGetAndSetDataCorrectly(string url)
        {
            var slide = new Slide { Image = url };

            Assert.AreEqual(slide.Image, url);
        }

        [TestCase(14)]
        [TestCase(11)]
        public void SliderId_ShouldGetAndSetDataCorrectly(int sliderId)
        {
            var slide = new Slide { SliderId = sliderId };

            Assert.AreEqual(slide.SliderId, sliderId);
        }

        [TestCase(11)]
        [TestCase(22)]
        public void Slider_ShouldGetAndSetDataCorrectly(int sliderId)
        {
            var slider = new Slider { Id = sliderId };
            var slide = new Slide { Slider = slider };

            Assert.AreEqual(slide.Slider.Id, sliderId);
        }
    }
}
