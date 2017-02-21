using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelRegistrationRequestTests
{
	[TestFixture]
	public class UpdateAccepted_Should
	{
		[Test]
		public void CallGetByIdOnce_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			mockedRepository.Setup(repository => repository.GetById(hotelRegistrationRequest.Object.Id)).Returns(hotelRegistrationRequest.Object);
			hotelRegistrationRequestService.UpdateAccepted(hotelRegistrationRequest.Object.Id, true);

			mockedRepository.Verify(repository => repository.GetById(hotelRegistrationRequest.Object.Id), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			mockedRepository.Setup(repository => repository.GetById(hotelRegistrationRequest.Object.Id)).Returns(hotelRegistrationRequest.Object);
			hotelRegistrationRequestService.UpdateAccepted(hotelRegistrationRequest.Object.Id, true);

			mockedUnitOfWork.Verify(unitOfWork => unitOfWork.SaveChanges(), Times.Once);
		}

		[Test]
		public void UpdateAcceptedProp_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			mockedRepository.Setup(repository => repository.GetById(hotelRegistrationRequest.Object.Id))
				.Returns(() => hotelRegistrationRequest.Object);

			hotelRegistrationRequestService.UpdateAccepted(hotelRegistrationRequest.Object.Id, true);

			Assert.AreEqual(hotelRegistrationRequest.Object.IsAccepted, true);
		}

		[Test]
		public void ThrowException_WhenRequestIsNull()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserHotelRegistrationRequest> hotelRegistrationRequest = null;

			Assert.Throws<NullReferenceException>(() => hotelRegistrationRequestService.UpdateAccepted(hotelRegistrationRequest.Object.Id, true));
		}
	}
}