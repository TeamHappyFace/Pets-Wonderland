using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Args;
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
			
			var args = new Mock<AddHotelRequestArgs>();
			hotelRegistrationRequestService.AddHotelRequest(args.Object.HotelName,
				args.Object.HotelLocation,args.Object.HotelManagerId, args.Object.HotelDescription,
				args.Object.DateOfRequest, args.Object.ImageUrl, args.Object.IsAccepted);
			
			mockedRepository.Verify(repository => repository.Add(It.IsAny<UserHotelRegistrationRequest>()));
		}

		[Test]
		public void InvokeAddMethodOnceForHotelRegistrationRequest_WhenParamsAreCorrect()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			var args = new Mock<AddHotelRequestArgs>();
			hotelRegistrationRequestService.AddHotelRequest(args.Object.HotelName,
				args.Object.HotelLocation, args.Object.HotelManagerId, args.Object.HotelDescription,
				args.Object.DateOfRequest, args.Object.ImageUrl, args.Object.IsAccepted);

			mockedRepository.Verify(repository => repository.Add(It.IsAny<UserHotelRegistrationRequest>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenHotelRegistrationRequestIsValid()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			var args = new Mock<AddHotelRequestArgs>();
			hotelRegistrationRequestService.AddHotelRequest(args.Object.HotelName,
				args.Object.HotelLocation, args.Object.HotelManagerId, args.Object.HotelDescription,
				args.Object.DateOfRequest, args.Object.ImageUrl, args.Object.IsAccepted);

			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenHotelRegistrationRequestIsInvalid()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			Mock<AddHotelRequestArgs> args = null;

			Assert.Throws<NullReferenceException>(() => hotelRegistrationRequestService.AddHotelRequest(args.Object.HotelName,
				args.Object.HotelLocation, args.Object.HotelManagerId, args.Object.HotelDescription,
				args.Object.DateOfRequest, args.Object.ImageUrl, args.Object.IsAccepted));
		}
	}
}
