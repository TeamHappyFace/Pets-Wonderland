using System;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Pages;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.SliderTests
{
	[TestFixture]
	public class DeleteSlider_Should
	{
		[Test]
		public void BeInvoked_WhenSlidertoDeleteIsValid()
		{
			var mockedRepository = new Mock<IRepository<Slider>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

			var slider = new Mock<Slider>();
			mockedRepository.Setup(repository => repository
					.GetFirst(sl => sl.Id == slider.Object.Id)).Returns(slider.Object);

			sliderService.DeleteSlider(slider.Object.Id);

			mockedRepository.Verify(repository => repository.GetFirst(It.IsAny<Expression<Func<Slider, bool>>>()), Times.Once);
		}

	    [Test]
	    public void InvokeSaveChanges_WhenParameterIsValid()
	    {
            // Arrange
            var mockedSlider = new Mock<Slider>();

            var mockedRepository = new Mock<IRepository<Slider>>();
            mockedRepository.SetupAllProperties();
            mockedRepository.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Slider, bool>>>()))
                .Returns(mockedSlider.Object);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);
            sliderService.DeleteSlider(mockedSlider.Object.Id);

            // Assert
            mockedUnitOfWork.Verify(unitOfWork => unitOfWork.SaveChanges(), Times.Once);
        }

        [Test]
        public void UpdateDeletedProp_WhenInvoked()
        {
            // Arrange
            var mockedSlider = new Mock<Slider>();
         
            var mockedRepository = new Mock<IRepository<Slider>>();
            mockedRepository.SetupAllProperties();
            mockedRepository.Setup(x => x.GetFirst(It.IsAny<Expression<Func<Slider, bool>>>()))
                .Returns(mockedSlider.Object);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
           

            // Act
            var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);           
            sliderService.DeleteSlider(mockedSlider.Object.Id);

            // Assert
            Assert.AreEqual(mockedSlider.Object.IsDeleted, true);
        }
    }
}