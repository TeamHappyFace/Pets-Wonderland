using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelRegistrationRequestTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateHotelRegistrationRequestService_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			Assert.That(hotelRegistrationRequestService, Is.InstanceOf<HotelRegistrationRequestService>());
		}

		[Test]
		public void ThrowNullException_WhenRepositoryIsNull()
		{
			Mock<IRepository<UserHotelRegistrationRequest>> mockedRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			
			Assert.Throws<NullReferenceException>(() => new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object));
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;
			
			Assert.Throws<NullReferenceException>(() => new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object));
		}
	}
}
