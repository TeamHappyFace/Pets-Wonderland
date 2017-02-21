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
	public class GetHotels_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			hotelService.GetHotels(1, 2);

			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void ReturnIList_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<Hotel> result = new List<Hotel>() { new Hotel(), new Hotel(), new Hotel() };
			mockedRepository.Setup(repository => repository.Entities).Returns(()=>result.AsQueryable());
			
			Assert.IsInstanceOf<IList<Hotel>>(hotelService.GetHotels(0, 3));
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<Hotel> result = new List<Hotel>() { new Hotel(), new Hotel() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.AreEqual(hotelService.GetHotels(0, 2), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoHotels()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<Hotel> result = new List<Hotel>();
			mockedRepository.Setup(repository => repository.Entities).Returns(() => result.AsQueryable());
			
			Assert.IsEmpty(hotelService.GetHotels(0,1));
		}

		[Test]
		public void ThrowException_WhenNullHotel()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<Hotel> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.Throws<ArgumentNullException>(() => hotelService.GetHotels(0,1));
		}
	}
}
