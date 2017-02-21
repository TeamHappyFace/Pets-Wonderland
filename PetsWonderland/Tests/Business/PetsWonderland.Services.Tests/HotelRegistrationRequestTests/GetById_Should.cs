using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelRegistrationRequestTests
{
	[TestFixture]
	public class GetById_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			hotelRegistrationRequestService.GetById(hotelRegistrationRequest.Object.Id);
			
			mockedRepository.Verify(repository => repository.GetById(hotelRegistrationRequest.Object.Id), Times.Once);
		}

		[Test]
		public void ReturnHotelRegistrationRequest_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			mockedRepository.Setup(repository => repository.GetById(hotelRegistrationRequest.Object.Id))
				.Returns(() => hotelRegistrationRequest.Object);
			
			Assert.IsInstanceOf<UserHotelRegistrationRequest>(hotelRegistrationRequestService.GetById(hotelRegistrationRequest.Object.Id));
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			mockedRepository.Setup(repository => repository.GetById(hotelRegistrationRequest.Object.Id))
				.Returns(() => hotelRegistrationRequest.Object);
			
			Assert.AreEqual(hotelRegistrationRequestService.GetById(hotelRegistrationRequest.Object.Id), hotelRegistrationRequest.Object);
		}

		[Test]
		public void ReturnCorrectHotelRegistrationRequest_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			var hotelRegistrationRequestToCompare = new Mock<UserHotelRegistrationRequest>();
			mockedRepository.Setup(repository => repository.GetById(hotelRegistrationRequest.Object.Id))
				.Returns(() => hotelRegistrationRequest.Object);
			
			Assert.AreNotEqual(hotelRegistrationRequestService.GetById(hotelRegistrationRequest.Object.Id), hotelRegistrationRequestToCompare.Object);
		}

		[Test]
		public void NotReturnHotelRegistrationRequest_WhenNoSuchHotelRegistrationRequest()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			mockedRepository.Setup(repository => repository.GetById(0)).Returns(() => null);
			
			Assert.IsNull(hotelRegistrationRequestService.GetById(0));
		}

		[Test]
		public void ThrowException_WhenNullHotelRegistrationRequest()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserHotelRegistrationRequest> hotelRegistrationRequest = null;
			
			Assert.Throws<NullReferenceException>(() => hotelRegistrationRequestService.GetById(hotelRegistrationRequest.Object.Id));
		}
	}
}
