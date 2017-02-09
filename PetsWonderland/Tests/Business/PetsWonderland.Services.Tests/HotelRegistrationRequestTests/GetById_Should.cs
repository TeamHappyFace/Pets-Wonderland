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
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			hotelRegistrationRequestService.GetById(hotelRegistrationRequest.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.GetById(hotelRegistrationRequest.Object.Id), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotUsed()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedRepository.Verify(repository => repository.GetById(1), Times.Never);
		}

		[Test]
		public void ReturnHotelRegistrationRequest_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			mockedRepository.Setup(repository => repository.GetById(hotelRegistrationRequest.Object.Id))
				.Returns(() => hotelRegistrationRequest.Object);

			//Act, Assert
			Assert.IsInstanceOf<UserHotelRegistrationRequest>(hotelRegistrationRequestService.GetById(hotelRegistrationRequest.Object.Id));
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			mockedRepository.Setup(repository => repository.GetById(hotelRegistrationRequest.Object.Id))
				.Returns(() => hotelRegistrationRequest.Object);

			//Assert
			Assert.AreEqual(hotelRegistrationRequestService.GetById(hotelRegistrationRequest.Object.Id), hotelRegistrationRequest.Object);
		}

		[Test]
		public void ReturnCorrectHotelRegistrationRequest_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var hotelRegistrationRequest = new Mock<UserHotelRegistrationRequest>();
			var hotelRegistrationRequestToCompare = new Mock<UserHotelRegistrationRequest>();
			mockedRepository.Setup(repository => repository.GetById(hotelRegistrationRequest.Object.Id))
				.Returns(() => hotelRegistrationRequest.Object);

			//Assert
			Assert.AreNotEqual(hotelRegistrationRequestService.GetById(hotelRegistrationRequest.Object.Id), hotelRegistrationRequestToCompare.Object);
		}

		[Test]
		public void NotReturnHotelRegistrationRequest_WhenNoSuchHotelRegistrationRequest()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			mockedRepository.Setup(repository => repository.GetById(0)).Returns(() => null);

			//Assert
			Assert.IsNull(hotelRegistrationRequestService.GetById(0));
		}

		[Test]
		public void ThrowException_WhenNullHotelRegistrationRequest()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			Mock<UserHotelRegistrationRequest> hotelRegistrationRequest = null;

			//Assert
			Assert.Throws<NullReferenceException>(() => hotelRegistrationRequestService.GetById(hotelRegistrationRequest.Object.Id));
		}
	}
}
