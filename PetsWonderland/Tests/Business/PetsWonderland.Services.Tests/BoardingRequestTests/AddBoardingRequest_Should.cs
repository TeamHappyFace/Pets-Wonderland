using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.BoardingRequestTests
{
	[TestFixture]
	public class AddBoardingRequest_Should
	{
		[Test]
		public void InvokeAddMethod_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var validUserBoardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.AddBoardingRequest(validUserBoardingRequest.Object);
			
			mockedRepository.Verify(repository => repository.Add(validUserBoardingRequest.Object));
		}

		[Test]
		public void InvokeAddMethodOnceForBoardingRequest_WhenParamsAreCorrect()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var validUserBoardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.AddBoardingRequest(validUserBoardingRequest.Object);
			
			mockedRepository.Verify(repository => repository.Add(It.IsAny<UserBoardingRequest>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenBoardingRequestIsValid()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var validUserBoardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.AddBoardingRequest(validUserBoardingRequest.Object);
			
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenBoardingRequestIsInvalid()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserBoardingRequest> validUserBoardingRequest = null;
			
			Assert.Throws<NullReferenceException>(() => boardingRequestService.AddBoardingRequest(validUserBoardingRequest.Object));
		}
	}
}
