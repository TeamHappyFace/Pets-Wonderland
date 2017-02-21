using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelLocationTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateHotelLocationService_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

			Assert.That(hotelLocationService, Is.InstanceOf<HotelLocationService>());
		}

		[Test]
		public void ThrowNullException_WhenRepositoryIsNull()
		{
			Mock<IRepository<HotelLocation>> mockedRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			Assert.Throws<NullReferenceException>(() => new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object));
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;

			Assert.Throws<NullReferenceException>(() => new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object));
		}
	}
}
