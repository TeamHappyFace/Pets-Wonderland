using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.HotelRegistrationRequestTests
{
	[TestFixture]
	public class GetAllHotelRequests_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			hotelRegistrationRequestService.GetAllHotelRequests();

			//Assert
			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotUsed()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedRepository.Verify(repository => repository.All(), Times.Never);
		}

		[Test]
		public void ReturnIqueriable_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<UserHotelRegistrationRequest> result = new List<UserHotelRegistrationRequest>()
			{ new UserHotelRegistrationRequest(), new UserHotelRegistrationRequest(), new UserHotelRegistrationRequest() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Act, Assert
			Assert.IsInstanceOf<IQueryable<UserHotelRegistrationRequest>>(hotelRegistrationRequestService.GetAllHotelRequests());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<UserHotelRegistrationRequest> result = new List<UserHotelRegistrationRequest>()
			{ new UserHotelRegistrationRequest(), new UserHotelRegistrationRequest(), new UserHotelRegistrationRequest() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.AreEqual(hotelRegistrationRequestService.GetAllHotelRequests(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoHotelRegistrationRequest()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<UserHotelRegistrationRequest> result = new List<UserHotelRegistrationRequest>();
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.IsEmpty(hotelRegistrationRequestService.GetAllHotelRequests());
		}

		[Test]
		public void ThrowException_WhenNullHotelRegistrationRequest()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<UserHotelRegistrationRequest> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.Throws<ArgumentNullException>(() => hotelRegistrationRequestService.GetAllHotelRequests());
		}
	}
}
