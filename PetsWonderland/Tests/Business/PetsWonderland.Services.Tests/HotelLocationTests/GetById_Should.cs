using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelLocationTests
{
	[TestFixture]
	public class GetById_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotelLocation = new Mock<HotelLocation>();
			hotelLocationService.GetById(hotelLocation.Object.Id);

			mockedRepository.Verify(repository => repository.GetById(hotelLocation.Object.Id), Times.Once);
		}

		[Test]
		public void ReturnHotelLocation_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotelLocation = new Mock<HotelLocation>();
			mockedRepository.Setup(repository => repository.GetById(hotelLocation.Object.Id))
				.Returns(() => hotelLocation.Object);

			Assert.IsInstanceOf<HotelLocation>(hotelLocationService.GetById(hotelLocation.Object.Id));
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotelLocation = new Mock<HotelLocation>();
			mockedRepository.Setup(repository => repository.GetById(hotelLocation.Object.Id))
				.Returns(() => hotelLocation.Object);

			Assert.AreEqual(hotelLocationService.GetById(hotelLocation.Object.Id), hotelLocation.Object);
		}

		[Test]
		public void ReturnCorrectHotelLocation_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotelLocation = new Mock<HotelLocation>();
			var hotelLocationToCompare = new Mock<HotelLocation>();
			mockedRepository.Setup(repository => repository.GetById(hotelLocation.Object.Id))
				.Returns(() => hotelLocation.Object);

			Assert.AreNotEqual(hotelLocationService.GetById(hotelLocation.Object.Id), hotelLocationToCompare.Object);
		}

		[Test]
		public void ReturnNull_WhenNoSuchHotelLocation()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

			mockedRepository.Setup(repository => repository.GetById(0)).Returns(() => null);

			Assert.IsNull(hotelLocationService.GetById(0));
		}

		[Test]
		public void ThrowException_WhenNullBoardingRequest()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<HotelLocation> hotelLocation = null;

			Assert.Throws<NullReferenceException>(() => hotelLocationService.GetById(hotelLocation.Object.Id));
		}
	}
}
