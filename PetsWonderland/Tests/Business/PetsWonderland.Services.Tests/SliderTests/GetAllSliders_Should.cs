using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Pages;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.SliderTests
{
	[TestFixture]
	public class GetAllSliders_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<Slider>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

			sliderService.GetAllSliders();

			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void ReturnIEnumerable_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<Slider>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Slider> result = new List<Slider>() { new Slider(), new Slider(), new Slider() };
			mockedRepository.Setup(repository => repository.All()).Returns(()=>result.AsQueryable());

			Assert.IsInstanceOf<IEnumerable<Slider>>(sliderService.GetAllSliders());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<Slider>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Slider> result = new List<Slider>() { new Slider(), new Slider(), new Slider() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.AreEqual(sliderService.GetAllSliders(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoSliders()
		{
			var mockedRepository = new Mock<IRepository<Slider>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Slider> result = new List<Slider>();
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.IsEmpty(sliderService.GetAllSliders());
		}

		[Test]
		public void ThrowException_WhenNullSlider()
		{
			var mockedRepository = new Mock<IRepository<Slider>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Slider> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			Assert.Throws<ArgumentNullException>(() => sliderService.GetAllSliders());
		}
	}
}
