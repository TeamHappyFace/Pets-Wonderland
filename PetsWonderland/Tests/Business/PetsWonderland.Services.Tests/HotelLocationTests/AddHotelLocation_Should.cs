using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelLocationTests
{
	[TestFixture]
	public class AddHotelLocation_Should
	{
		[Test]
		public void InvokeAddMethod_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

			var validHotelLocation = new Mock<HotelLocation>();
			hotelLocationService.AddHotelLocation(validHotelLocation.Object);

			mockedRepository.Verify(repository => repository.Add(validHotelLocation.Object));
		}

		[Test]
		public void InvokeAddMethodOnceForHotelLocation_WhenParamsAreCorrect()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

			var validHotelLocation = new Mock<HotelLocation>();
			hotelLocationService.AddHotelLocation(validHotelLocation.Object);

			mockedRepository.Verify(repository => repository.Add(It.IsAny<HotelLocation>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenHotelLocationIsValid()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

			var validHotelLocation = new Mock<HotelLocation>();
			hotelLocationService.AddHotelLocation(validHotelLocation.Object);

			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenHotelLocationIsNull()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<HotelLocation> validUserBoardingRequest = null;

			Assert.Throws<NullReferenceException>(() => hotelLocationService.AddHotelLocation(validUserBoardingRequest.Object));
		}
	}
}
