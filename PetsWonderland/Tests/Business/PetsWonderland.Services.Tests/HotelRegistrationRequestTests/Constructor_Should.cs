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
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			Assert.That(hotelRegistrationRequestService, Is.InstanceOf<HotelRegistrationRequestService>());
		}

		[Test]
		public void ThrowNullException_WhenRepositoryIsNull()
		{
			//Arrange
			Mock<IRepository<UserHotelRegistrationRequest>> mockedRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object));
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object));
		}
	}
}
