using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelTests
{
	[TestFixture]
	public class GetAllHotels_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			hotelService.GetAllHotels();

			//Assert
			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotUsed()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedRepository.Verify(repository => repository.All(), Times.Never);
		}

		[Test]
		public void ReturnIqueriable_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Hotel> result = new List<Hotel>() { new Hotel(), new Hotel(), new Hotel() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Act, Assert
			Assert.IsInstanceOf<IQueryable<Hotel>>(hotelService.GetAllHotels());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<Hotel> result = new List<Hotel>() { new Hotel(), new Hotel(), new Hotel() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.AreEqual(hotelService.GetAllHotels(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoHotels()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<Hotel> result = new List<Hotel>();
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.IsEmpty(hotelService.GetAllHotels());
		}

		[Test]
		public void ThrowException_WhenNullHotel()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<Hotel> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.Throws<ArgumentNullException>(() => hotelService.GetAllHotels());
		}
	}
}
