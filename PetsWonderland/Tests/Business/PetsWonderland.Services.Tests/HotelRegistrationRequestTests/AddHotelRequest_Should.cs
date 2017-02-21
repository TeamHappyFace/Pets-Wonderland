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
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var validHotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			hotelRegistrationRequestService.AddHotelRequest(validHotelRegistrationRequest.Object);
			
			mockedRepository.Verify(repository => repository.Add(validHotelRegistrationRequest.Object));
		}

		[Test]
		public void InvokeAddMethodOnceForHotelRegistrationRequest_WhenParamsAreCorrect()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var validHotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			hotelRegistrationRequestService.AddHotelRequest(validHotelRegistrationRequest.Object);
			
			mockedRepository.Verify(repository => repository.Add(It.IsAny<UserHotelRegistrationRequest>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenHotelRegistrationRequestIsValid()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var validHotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			hotelRegistrationRequestService.AddHotelRequest(validHotelRegistrationRequest.Object);
			
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenHotelRegistrationRequestIsInvalid()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserHotelRegistrationRequest> validHotelRegistrationRequest = null;
			
			Assert.Throws<NullReferenceException>(() => hotelRegistrationRequestService.AddHotelRequest(validHotelRegistrationRequest.Object));
		}
	}
}
