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
			//Arrange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserBoardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.AddBoardingRequest(validUserBoardingRequest.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(validUserBoardingRequest.Object));
		}

		[Test]
		public void InvokeAddMethodOnceForBoardingRequest_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserBoardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.AddBoardingRequest(validUserBoardingRequest.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(It.IsAny<UserBoardingRequest>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenBoardingRequestIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserBoardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.AddBoardingRequest(validUserBoardingRequest.Object);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenBoardingRequestIsInvalid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserBoardingRequest> validUserBoardingRequest = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => boardingRequestService.AddBoardingRequest(validUserBoardingRequest.Object));
		}
	}
}
