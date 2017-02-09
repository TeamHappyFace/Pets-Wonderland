using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelTests
{
	[TestFixture]
	public class DeleteHotelById_Should
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
			hotelService.DeleteHotelById(validHotel.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(validHotel.Object.Id));
		}

		[Test]
		public void BeInvokedOnceForTypeHotel_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotel = new Mock<Hotel>();
			hotelService.AddHotel(validHotel.Object);
			hotelService.DeleteHotelById(validHotel.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(validHotel.Object.Id), Times.Once);
		}

		[Test]
		public void CallSaveChangesTwice_WhenParamsAreValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotel = new Mock<Hotel>();
			hotelService.AddHotel(validHotel.Object);
			hotelService.DeleteHotelById(validHotel.Object.Id);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Exactly(2));
		}

		[Test]
		public void NotDeleteByIdHotel_WhichIsNotAdded()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotel = new Mock<Hotel>();

			//Act, Assert
			mockedRepository.Verify(repository => repository.Delete(hotel.Object.Id), Times.Never);
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
			Assert.Throws<NullReferenceException>(() => hotelService.DeleteHotelById(hotel.Object.Id));
		}
	}
}
