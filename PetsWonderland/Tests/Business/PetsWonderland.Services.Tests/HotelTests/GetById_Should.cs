using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelTests
{
	[TestFixture]
	public class GetById_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var hotel = new Mock<Hotel>();
			hotelService.GetById(hotel.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.GetById(hotel.Object.Id), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotUsed()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedRepository.Verify(repository => repository.GetById(1), Times.Never);
		}

		[Test]
		public void ReturnHotel_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotel = new Mock<Hotel>();
			mockedRepository.Setup(repository => repository.GetById(hotel.Object.Id)).Returns(() => hotel.Object);

			//Act, Assert
			Assert.IsInstanceOf<Hotel>(hotelService.GetById(hotel.Object.Id));
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var hotel = new Mock<Hotel>();
			mockedRepository.Setup(repository => repository.GetById(hotel.Object.Id)).Returns(() => hotel.Object);

			//Assert
			Assert.AreEqual(hotelService.GetById(hotel.Object.Id), hotel.Object);
		}

		[Test]
		public void ReturnCorrectHotel_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var hotel = new Mock<Hotel>();
			var hotelToCompare = new Mock<Hotel>();
			mockedRepository.Setup(repository => repository.GetById(hotel.Object.Id)).Returns(() => hotel.Object);

			//Assert
			Assert.AreNotEqual(hotelService.GetById(hotel.Object.Id), hotelToCompare.Object);
		}

		[Test]
		public void NotReturnHotel_WhenNoSuchHotel()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			mockedRepository.Setup(repository => repository.GetById(0)).Returns(() => null);

			//Assert
			Assert.IsNull(hotelService.GetById(0));
		}

		[Test]
		public void ThrowException_WhenNullHotel()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			Mock<Hotel> hotel = null;

			//Assert
			Assert.Throws<NullReferenceException>(() => hotelService.GetById(hotel.Object.Id));
		}
	}
}
