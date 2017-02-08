using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Business.Tests.Services.HotelServiceTests
{
	[TestFixture]
	public class AddHotel_Should
	{
		[Test]
		public void InvokeAddMethod_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotel = new Mock<Hotel>();
			hotelService.AddHotel(validHotel.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(validHotel.Object));
		}

		[Test]
		public void InvokeAddMethodOnceForHotel_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotel = new Mock<Hotel>();
			hotelService.AddHotel(validHotel.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(It.IsAny<Hotel>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenHotelIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotel = new Mock<Hotel>();
			hotelService.AddHotel(validHotel.Object);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenHotelIsInvalid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<Hotel> hotelToAdd = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => hotelService.AddHotel(hotelToAdd.Object));
		}
	}
}
