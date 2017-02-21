using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelTests
{
	[TestFixture]
	public class GetHotelLocation_Should
	{
		[Test]
		public void ReturnCorrectHotelLocation_WhenHotelIsValid()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var validHotel = new Mock<Hotel>();
			var location = new HotelLocation();
			validHotel.Setup(hotel => hotel.Location).Returns(location);
			
			Assert.AreEqual(location, hotelService.GetHotelLocation(validHotel.Object));
		}

		[Test]
		public void ReturnInstanceHotelLocation_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var validHotel = new Mock<Hotel>();
			var location = new HotelLocation();
			validHotel.Setup(hotel => hotel.Location).Returns(location);
			
			Assert.IsInstanceOf<HotelLocation>(validHotel.Object.Location);
		}

		[Test]
		public void ReturnsNull_WhenHotelLocationIsNotAssigned()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var validHotel = new Mock<Hotel>();
			
			Assert.IsNull(hotelService.GetHotelLocation(validHotel.Object));
		}

		[Test]
		public void ThrowException_WhenHotelIsNull()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			Mock<Hotel> hotel = null;
			
			Assert.That(() => hotelService.GetHotelLocation(hotel.Object),
				Throws.InstanceOf<NullReferenceException>());
		}
	}
}
