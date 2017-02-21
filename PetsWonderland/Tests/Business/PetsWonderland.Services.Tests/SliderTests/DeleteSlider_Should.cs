using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

		//[Test]
		//public void CallSaveChanges_WhenParamsAreValid()
		//{
		//	var mockedRepository = new Mock<IRepository<Slider>>();
		//	var mockedUnitOfWork = new Mock<IUnitOfWork>();
		//	var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

		//	var slider = new Mock<Slider>();

		//	mockedRepository.Setup(repository => repository
		//			.GetFirst(sl => sl.Id == slider.Object.Id)).Returns(slider.Object);
			
		//	sliderService.DeleteSlider(slider.Object.Id);

		//	mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		//}
	}
}