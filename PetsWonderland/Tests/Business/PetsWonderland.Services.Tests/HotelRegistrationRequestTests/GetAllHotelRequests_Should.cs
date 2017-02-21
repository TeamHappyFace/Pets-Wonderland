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
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			hotelRegistrationRequestService.GetAllHotelRequests();
			
			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void ReturnIqueriable_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<UserHotelRegistrationRequest> result = new List<UserHotelRegistrationRequest>()
			{ new UserHotelRegistrationRequest(), new UserHotelRegistrationRequest(), new UserHotelRegistrationRequest() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.IsInstanceOf<IQueryable<UserHotelRegistrationRequest>>(hotelRegistrationRequestService.GetAllHotelRequests());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<UserHotelRegistrationRequest> result = new List<UserHotelRegistrationRequest>()
			{
				new UserHotelRegistrationRequest() { IsAccepted = false, IsDeleted = false },
				new UserHotelRegistrationRequest() { IsAccepted = false, IsDeleted = false },
				new UserHotelRegistrationRequest() { IsAccepted = false, IsDeleted = false }
			};
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.AreEqual(hotelRegistrationRequestService.GetAllHotelRequests(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoHotelRegistrationRequest()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<UserHotelRegistrationRequest> result = new List<UserHotelRegistrationRequest>();
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.IsEmpty(hotelRegistrationRequestService.GetAllHotelRequests());
		}

		[Test]
		public void ThrowException_WhenNullHotelRegistrationRequest()
		{
			var mockedRepository = new Mock<IRepository<UserHotelRegistrationRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelRegistrationRequestService = new HotelRegistrationRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<UserHotelRegistrationRequest> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.Throws<ArgumentNullException>(() => hotelRegistrationRequestService.GetAllHotelRequests());
		}
	}
}
