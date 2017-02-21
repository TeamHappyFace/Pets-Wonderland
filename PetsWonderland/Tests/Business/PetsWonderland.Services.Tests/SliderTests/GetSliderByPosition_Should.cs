using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Pages;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.SliderTests
{
	[TestFixture]
	public class GetSliderByPosition_Should
	{
		[Test]
		public void CallEntities_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<Slider>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

			var slider = new Mock<Slider>();
			sliderService.GetSliderByPosition(" ");

			mockedRepository.Verify(repository => repository.Entities, Times.Once);
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<Slider>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

			var slider = new Mock<Slider>();
			slider.Object.Position = " ";
			mockedRepository.Setup(repository => repository.Entities)
				.Returns(() => new List<Slider>() { slider.Object }.AsQueryable());

			Assert.AreEqual(sliderService.GetSliderByPosition(" "), slider.Object);
		}

		[Test]
		public void ThrowException_WhenNullSlider()
		{
			var mockedRepository = new Mock<IRepository<Slider>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<Slider> slider = null;

			Assert.Throws<NullReferenceException>(() => sliderService.GetSliderByPosition(slider.Object.Position));
		}
	}
}
