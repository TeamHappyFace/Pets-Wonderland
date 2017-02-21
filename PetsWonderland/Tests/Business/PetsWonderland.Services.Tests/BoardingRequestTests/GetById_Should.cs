using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.BoardingRequestTests
{
	[TestFixture]
	public class GetById_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var boardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.GetById(boardingRequest.Object.Id);
			
			mockedRepository.Verify(repository => repository.GetById(boardingRequest.Object.Id), Times.Once);
		}

		[Test]
		public void ReturnBoardingRequest_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			var boardingRequest = new Mock<UserBoardingRequest>();
			mockedRepository.Setup(repository => repository.GetById(boardingRequest.Object.Id))
				.Returns(() => boardingRequest.Object);
			
			Assert.IsInstanceOf<UserBoardingRequest>(boardingRequestService.GetById(boardingRequest.Object.Id));
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var boardingRequest = new Mock<UserBoardingRequest>();
			mockedRepository.Setup(repository => repository.GetById(boardingRequest.Object.Id))
				.Returns(() => boardingRequest.Object);
			
			Assert.AreEqual(boardingRequestService.GetById(boardingRequest.Object.Id), boardingRequest.Object);
		}

		[Test]
		public void ReturnCorrectBoardingRequest_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var boardingRequest = new Mock<UserBoardingRequest>();
			var boardingRequestToCompare = new Mock<UserBoardingRequest>();
			mockedRepository.Setup(repository => repository.GetById(boardingRequest.Object.Id))
				.Returns(() => boardingRequest.Object);
			
			Assert.AreNotEqual(boardingRequestService.GetById(boardingRequest.Object.Id), boardingRequestToCompare.Object);
		}

		[Test]
		public void NotReturnBoardingRequest_WhenNoSuchBoardingRequest()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			mockedRepository.Setup(repository => repository.GetById(0)).Returns(() => null);
			
			Assert.IsNull(boardingRequestService.GetById(0));
		}

		[Test]
		public void ThrowException_WhenNullBoardingRequest()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			Mock<UserBoardingRequest> boardingRequest = null;
			
			Assert.Throws<NullReferenceException>(() => boardingRequestService.GetById(boardingRequest.Object.Id));
		}
	}
}
