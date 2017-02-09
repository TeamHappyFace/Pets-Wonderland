using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelTests
{
	[TestFixture]
	public class GetByName_Should
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
			hotelService.GetByName(hotel.Object.Name);

			//Assert
			mockedRepository.Verify(repository => repository.GetByName(hotel.Object.Name), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotUsed()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedRepository.Verify(repository => repository.GetByName("Pesho"), Times.Never);
		}

		[Test]
		public void ReturnHotel_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var hotel = new Mock<Hotel>();
			mockedRepository.Setup(repository => repository.GetByName(hotel.Object.Name)).Returns(() => hotel.Object);

			//Assert
			Assert.IsInstanceOf<Hotel>(hotelService.GetByName(hotel.Object.Name));
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
			mockedRepository.Setup(repository => repository.GetByName(hotel.Object.Name)).Returns(() => hotel.Object);

			//Assert
			Assert.AreEqual(hotelService.GetByName(hotel.Object.Name), hotel.Object);
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
			mockedRepository.Setup(repository => repository.GetByName(hotel.Object.Name)).Returns(() => hotel.Object);

			//Assert
			Assert.AreNotEqual(hotelService.GetByName(hotel.Object.Name), hotelToCompare.Object);
		}

		[Test]
		public void NotReturnHotel_WhenNoSuchHotel()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			mockedRepository.Setup(repository => repository.GetByName("Zoro")).Returns(() => null);

			//Assert
			Assert.IsNull(hotelService.GetByName("Zoro"));
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
			Assert.Throws<NullReferenceException>(() => hotelService.GetByName(hotel.Object.Name));
		}
	}
}
