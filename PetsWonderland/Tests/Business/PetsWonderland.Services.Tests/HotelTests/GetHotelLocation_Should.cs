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
			//Arrange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotel = new Mock<Hotel>();
			var location = new HotelLocation();
			validHotel.Setup(hotel => hotel.Location).Returns(location);

			//Assert
			Assert.AreEqual(location, hotelService.GetHotelLocation(validHotel.Object));
		}

		[Test]
		public void ReturnInstanceHotelLocation_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotel = new Mock<Hotel>();
			var location = new HotelLocation();
			validHotel.Setup(hotel => hotel.Location).Returns(location);

			//Assert
			Assert.IsInstanceOf<HotelLocation>(validHotel.Object.Location);
		}

		[Test]
		public void ReturnsNull_WhenHotelLocationIsNotAssigned()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotel = new Mock<Hotel>();

			//Assert
			Assert.IsNull(hotelService.GetHotelLocation(validHotel.Object));
		}

		[Test]
		public void ThrowException_WhenHotelIsNull()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			Mock<Hotel> hotel = null;

			//Assert
			Assert.That(() => hotelService.GetHotelLocation(hotel.Object),
				Throws.InstanceOf<NullReferenceException>());
		}
	}
}
