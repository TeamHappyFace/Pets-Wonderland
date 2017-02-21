using System;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelLocationTests
{
	[TestFixture]
	public class GetByAddress_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<HotelLocation>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

			var address = "Bulgaria";
			mockedRepository.Setup(repository => repository.Add(It.IsAny<HotelLocation>()));
			mockedRepository.Setup(repository => repository.GetFirst(l => l.Address == address))
				.Returns(() => It.IsAny<HotelLocation>());
			hotelLocationService.GetByAddress(address);

			mockedRepository.Verify(repository => repository.GetFirst(It.IsAny<Expression<Func<HotelLocation, bool>>>()), Times.Once);
		}

		//[Test]
		//public void ReturnHotelLocation_WhenInvoked()
		//{
		//	var mockedRepository = new Mock<IRepository<HotelLocation>>();
		//	var mockedUnitOfWork = new Mock<IUnitOfWork>();
		//	var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);
			
		//	mockedRepository.Setup(repository => repository.Add(It.IsAny<HotelLocation>()));
		//	mockedRepository.Setup(repository => repository.GetFirst(It.IsAny<Expression<Func<HotelLocation, bool>>>()))
		//		.Returns(() => It.IsAny<HotelLocation>());

		//	Assert.IsInstanceOf<HotelLocation>(hotelLocationService.GetByAddress(It.IsAny<string>()));
		//}
	}
}
