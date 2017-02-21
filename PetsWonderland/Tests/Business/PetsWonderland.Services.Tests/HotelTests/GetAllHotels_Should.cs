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
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			hotelService.GetAllHotels();
			
			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void ReturnIqueriable_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Hotel> result = new List<Hotel>() { new Hotel(), new Hotel(), new Hotel() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.IsInstanceOf<IQueryable<Hotel>>(hotelService.GetAllHotels());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<Hotel> result = new List<Hotel>() { new Hotel(), new Hotel(), new Hotel() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.AreEqual(hotelService.GetAllHotels(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoHotels()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<Hotel> result = new List<Hotel>();
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.IsEmpty(hotelService.GetAllHotels());
		}

		[Test]
		public void ThrowException_WhenNullHotel()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<Hotel> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.Throws<ArgumentNullException>(() => hotelService.GetAllHotels());
		}
	}
}
