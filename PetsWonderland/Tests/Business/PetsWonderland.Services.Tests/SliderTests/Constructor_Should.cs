using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Pages;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.SliderTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateSliderService_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<Slider>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var sliderService = new SliderService(mockedRepository.Object, mockedUnitOfWork.Object);

			Assert.That(sliderService, Is.InstanceOf<SliderService>());
		}

		[Test]
		public void ThrowNullException_WhenRepositoryIsNull()
		{
			Mock<IRepository<Slider>> mockedRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			Assert.Throws<NullReferenceException>(() => new SliderService(mockedRepository.Object, mockedUnitOfWork.Object));
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			var mockedRepository = new Mock<IRepository<Slider>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;

			Assert.Throws<NullReferenceException>(() => new SliderService(mockedRepository.Object, mockedUnitOfWork.Object));
		}
	}
}
