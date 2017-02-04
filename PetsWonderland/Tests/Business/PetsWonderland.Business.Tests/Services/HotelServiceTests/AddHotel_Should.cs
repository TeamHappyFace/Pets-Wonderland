using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Business.Tests.Services.HotelServiceTests
{
	[TestClass]
	public class AddHotel_Should
	{
		[TestMethod]
		public void TestMethod1()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			var validHotel = new Mock<Hotel>();
			hotelService.AddHotel(validHotel.Object);

			Assert.IsNotNull(mockedRepository.Object);
		}
	}
}
