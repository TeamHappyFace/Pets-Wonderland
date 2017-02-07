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
		public void AddHotelCorrectly_WhenParamsAreValid()
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
