using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelRegistrationRequestTests
{
	[TestFixture]
	public class AddHotelRequest_Should
	{
		[Test]
		public void InvokeAddMethod_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			hotelRegistrationRequestService.AddHotelRequest(validHotelRegistrationRequest.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(validHotelRegistrationRequest.Object));
		}

		[Test]
		public void InvokeAddMethodOnceForHotelRegistrationRequest_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			hotelRegistrationRequestService.AddHotelRequest(validHotelRegistrationRequest.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(It.IsAny<UserHotelRegistrationRequest>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenHotelRegistrationRequestIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validHotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			hotelRegistrationRequestService.AddHotelRequest(validHotelRegistrationRequest.Object);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenHotelRegistrationRequestIsInvalid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserHotelRegistrationRequest> validHotelRegistrationRequest = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => hotelRegistrationRequestService.AddHotelRequest(validHotelRegistrationRequest.Object));
		}
	}
}
