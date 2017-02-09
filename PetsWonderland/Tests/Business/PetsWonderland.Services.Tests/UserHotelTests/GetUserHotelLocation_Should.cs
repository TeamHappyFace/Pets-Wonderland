using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.UserHotelTests
{
	[TestFixture]
	public class GetUserHotelLocation_Should
	{
		[Test]
		public void ReturnCorrectUserHotelLocation_WhenUserHotelIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserHotel = new Mock<UserHotel>();
			var location = new HotelLocation();
			validUserHotel.Setup(hotel => hotel.Hotel.Location).Returns(location);

			//Assert
			Assert.AreEqual(location, userHotelService.GetUserHotelLocation(validUserHotel.Object));
		}

		[Test]
		public void ReturnInstanceUserHotelLocation_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserHotel = new Mock<UserHotel>();
			var location = new HotelLocation();
			validUserHotel.Setup(hotel => hotel.Hotel.Location).Returns(location);

			//Assert
			Assert.IsInstanceOf<HotelLocation>(validUserHotel.Object.Hotel.Location);
		}

		[Test]
		public void ReturnsNull_WhenUserHotelLocationIsNotAssigned()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserHotel = new Mock<UserHotel>();
			validUserHotel.Setup(hotel => hotel.Hotel.Location).Returns(()=>null);

			//Assert
			Assert.IsNull(userHotelService.GetUserHotelLocation(validUserHotel.Object));
		}

		[Test]
		public void ThrowException_WhenUserHotelIsNull()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			Mock<UserHotel> userHotel = null;

			//Assert
			Assert.That(() => userHotelService.GetUserHotelLocation(userHotel.Object),
				Throws.InstanceOf<NullReferenceException>());
		}
	}
}
