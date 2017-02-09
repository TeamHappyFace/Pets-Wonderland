using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.BoardingRequestTests
{
	[TestFixture]
	public class DeleteBoardingRequest_Should
	{
		[Test]
		public void BeInvoked_WhenBoardingRequestToDeleteIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var boardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.AddBoardingRequest(boardingRequest.Object);
			boardingRequestService.DeleteBoardingRequest(boardingRequest.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(boardingRequest.Object));
		}

		[Test]
		public void BeInvokedOnceForBoardingRequest_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var boardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.AddBoardingRequest(boardingRequest.Object);
			boardingRequestService.DeleteBoardingRequest(boardingRequest.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(It.IsAny<UserBoardingRequest>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesTwice_WhenBoardingRequestIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var boardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.AddBoardingRequest(boardingRequest.Object);
			boardingRequestService.DeleteBoardingRequest(boardingRequest.Object);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Exactly(2));
		}

		[Test]
		public void NotCallSaveChanges_WhenBoardingRequestIsNotDeleted()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Never);
		}

		[Test]
		public void NotDeleteBoardingRequest_WhichIsNotAdded()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			var boardingRequest = new Mock<UserBoardingRequest>();

			//Act, Assert
			mockedRepository.Verify(repository => repository.Delete(boardingRequest.Object), Times.Never);
		}

		[Test]
		public void ThrowException_WhenBoardingRequestIsNull()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserBoardingRequest> boardingRequest = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => boardingRequestService.DeleteBoardingRequest(boardingRequest.Object));
		}
	}
}
