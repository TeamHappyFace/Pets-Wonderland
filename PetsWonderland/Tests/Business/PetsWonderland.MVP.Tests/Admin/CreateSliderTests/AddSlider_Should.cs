using System.Collections.Generic;
using System.Web;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Admin.CreateSlider;
using PetsWonderland.Business.MVP.Admin.CreateSlider.Args;
using PetsWonderland.Business.MVP.Admin.CreateSlider.ViewModels;
using PetsWonderland.Business.MVP.Admin.CreateSlider.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Admin.CreateSliderTests
{
    [TestFixture]
    public class AddSlider_Should
    {
        [Test]
        public void Work_WhenValid()
        {
            var mockedSliderCreatetView = new Mock<ICreateSliderView>();
            var mockedSliderService = new Mock<ISliderService>();

            mockedSliderCreatetView
                .SetupGet(x => x.Model)
                .Returns(new CreateSliderViewModel());

            var createSliderPresenter = new CreateSliderPresenter(
                mockedSliderCreatetView.Object,
                mockedSliderService.Object);

            var args = new CreateSliderArgs()
            {               
                Name = It.IsAny<string>(),
                Postition = It.IsAny<string>(),
                ImageStoragePath = It.IsAny<string>(),
                SlidesOptions = It.IsAny<IDictionary<int, List<KeyValuePair<string, string>>>>(),
                SlidesImages = It.IsAny<IDictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>>>(),
            };

            mockedSliderCreatetView.Raise(x => x.CreateSlider += null, args);

            mockedSliderService.Verify(x => x.CreateSlider(
                args.Name,
                args.Postition,
                args.ImageStoragePath,
                args.SlidesOptions, 
                args.SlidesImages), 
                Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldReturnSuccessSetValue(bool result)
        {            
            var sliderViewModel = new CreateSliderViewModel { SliderCreatedSuccessfully = result };
        
            Assert.AreEqual(sliderViewModel.SliderCreatedSuccessfully, result);
        }
    }
}
