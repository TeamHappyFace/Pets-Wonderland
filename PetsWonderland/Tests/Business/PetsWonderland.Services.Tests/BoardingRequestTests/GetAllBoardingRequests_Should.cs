using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.BoardingRequestTests
{
	[TestFixture]
	public class GetAllBoardingRequests_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			boardingRequestService.GetAllBoardingRequests();

			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void ReturnIqueriable_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<UserBoardingRequest> result = new List<UserBoardingRequest>()
			{ new UserBoardingRequest(), new UserBoardingRequest(), new UserBoardingRequest() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.IsInstanceOf<IQueryable<UserBoardingRequest>>(boardingRequestService.GetAllBoardingRequests());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<UserBoardingRequest> result = new List<UserBoardingRequest>()
			{ new UserBoardingRequest(), new UserBoardingRequest(), new UserBoardingRequest() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.AreEqual(boardingRequestService.GetAllBoardingRequests(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoBoardingRequests()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<UserBoardingRequest> result = new List<UserBoardingRequest>();
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.IsEmpty(boardingRequestService.GetAllBoardingRequests());
		}

		[Test]
		public void ThrowException_WhenNullBoardinRequest()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			IEnumerable<UserBoardingRequest> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());
			
			Assert.Throws<ArgumentNullException>(() => boardingRequestService.GetAllBoardingRequests());
		}
	}
}
