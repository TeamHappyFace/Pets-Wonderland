using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Pages;
using PetsWonderland.Business.Models.Pages.Contracts;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.SliderTests
{
    [TestFixture]
    public class Create_Should
    {
        [TestCase("")]
        [TestCase(null)]
        public void ThrowArgumentException_WhenParameterNameIsNullOrEmpty(string invalidName)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Slider>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSlidesOptions = new Mock<IDictionary<int, List<KeyValuePair<string, string>>>>();
            var mockedSlidesImages = new Mock<IDictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>>>();

            var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act & Assert
            Assert.That(
                () => sliderService.CreateSlider(
                    invalidName,
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    mockedSlidesOptions.Object,
                    mockedSlidesImages.Object),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("Slider must have a name!")
            );
        }

        [TestCase("")]
        [TestCase(null)]
        public void ThrowArgumentException_WhenParameterPositionIsNullOrEmpty(string invalidPosition)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Slider>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSlidesOptions = new Mock<IDictionary<int, List<KeyValuePair<string, string>>>>();
            var mockedSlidesImages = new Mock<IDictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>>>();

            var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act & Assert
            Assert.That(
                () => sliderService.CreateSlider(
                    It.IsAny<string>(),
                    invalidPosition,
                    It.IsAny<string>(),
                    mockedSlidesOptions.Object,
                    mockedSlidesImages.Object),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("Slider must have a name!")
            );
        }

        [TestCase("")]
        [TestCase(null)]
        public void ThrowArgumentException_WhenParameterStoragePathIsNullOrEmpty(string invalidPath)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Slider>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSlidesOptions = new Mock<IDictionary<int, List<KeyValuePair<string, string>>>>();
            var mockedSlidesImages = new Mock<IDictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>>>();

            var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act & Assert
            Assert.That(
                () => sliderService.CreateSlider(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    invalidPath,
                    mockedSlidesOptions.Object,
                    mockedSlidesImages.Object),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("Slider must have a name!")
            );
        }

        [TestCase(null)]
        public void ThrowArgumentException_WhenParameterSlidesOptionsnIsNull(
            IDictionary<int, List<KeyValuePair<string, string>>> invalidSlidesOptions)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Slider>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSlidesImages = new Mock<IDictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>>>();

            var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act & Assert
            const string title = "hpslider";
            const string position = "hp";
            const string storage = "/slider/";
            Assert.That(
                () => sliderService.CreateSlider(
                    title,
                    position,
                    storage,
                    invalidSlidesOptions,
                    mockedSlidesImages.Object),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("Slides options cannot be null!")
            );
        }

        [TestCase(null)]
        public void ThrowArgumentException_WhenParameterSlidesImagesnIsNull(
            IDictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>> invalidSlidesImages)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Slider>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSlidesOptions = new Mock<IDictionary<int, List<KeyValuePair<string, string>>>>();
            mockedSlidesOptions.SetupAllProperties();

            var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act & Assert
            const string title = "hpslider";
            const string position = "hp";
            const string storage = "/slider/";
            Assert.That(
                () => sliderService.CreateSlider(
                    title,
                    position,
                    storage,
                    mockedSlidesOptions.Object,
                    invalidSlidesImages),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("Slides images cannot be null!")
            );
        }

        [Test]
        public void SaveNewSlider_WhenArgumentsAreValid()
        {
            // Arrange   
            var mockedRepository = new Mock<IRepository<Slider>>();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            mockedUnitOfWork.Setup(x => x.SaveChanges());

            var slidesOptions = new Dictionary<int, List<KeyValuePair<string, string>>>
            {
                {
                    1,
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("SlideTitle", "a"),
                        new KeyValuePair<string, string>("SlideCaption", "b"),
                        new KeyValuePair<string, string>("SlideImageName", "s")
                    }
                }
            };
                
            var fileBase = new Mock<HttpPostedFileBase>();
            var slidesImages = new Dictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>>
            {
                {
                    1,
                    new List<KeyValuePair<string, HttpPostedFileBase>>
                    {
                        new KeyValuePair<string, HttpPostedFileBase>("SlideImage", fileBase.Object)
                    }
                }
            };

            // Act
            var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

            const string title = "hpslider";
            const string position = "hp";
            const string storage = "/slider/";
            sliderService.CreateSlider(title, position, storage, slidesOptions, slidesImages);

            // Assert
            mockedUnitOfWork.Verify(x => x.SaveChanges(), Times.Exactly(1));
        }

        [Test]
        public void ReturnFalseResult_WhenSaveBlockFails()
        {
            // Arrange   
            var mockedRepository = new Mock<IRepository<Slider>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSlidesOptions = new Mock<IDictionary<int, List<KeyValuePair<string, string>>>>();
            var mockedSlidesImages = new Mock<IDictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>>>();

            // Act
            var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

            const string title = "hpslider";
            const string position = "hp";
            const string storage = "/slider/";
            var result = sliderService.CreateSlider(title, position, storage, mockedSlidesOptions.Object, mockedSlidesImages.Object);

            Assert.AreEqual(result, false);
        }
    }
}
