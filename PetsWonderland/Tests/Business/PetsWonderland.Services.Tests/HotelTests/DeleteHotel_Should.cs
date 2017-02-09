using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelTests
{
	[TestFixture]
	public class DeleteHotel_Should
	{
		[Test]
		public void BeInvoked_WhenHoteltoDeleteIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotel = new Mock<Hotel>();
			hotelService.AddHotel(validHotel.Object);
			hotelService.DeleteHotel(validHotel.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(validHotel.Object));
		}

		[Test]
		public void BeInvokedOnceForHotel_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotel = new Mock<Hotel>();
			hotelService.AddHotel(validHotel.Object);
			hotelService.DeleteHotel(validHotel.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(It.IsAny<Hotel>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesTwice_WhenHotelIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotel = new Mock<Hotel>();
			hotelService.AddHotel(validHotel.Object);
			hotelService.DeleteHotel(validHotel.Object);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Exactly(2));
		}

		[Test]
		public void NotCallSaveChanges_WhenHotelIsNotDeleted()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			//Act, Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Never);
		}

		[Test]
		public void NotDeleteHotel_WhichIsNotAdded()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotel = new Mock<Hotel>();

			//Act, Assert
			mockedRepository.Verify(repository => repository.Delete(hotel.Object), Times.Never);
		}

		[Test]
		public void ThrowException_WhenHotelIsNull()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<Hotel> hotel = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => hotelService.DeleteHotel(hotel.Object));
		}
	}
}
