using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.BoardingRequestTests
{
	[TestFixture]
	public class DeleteBoardingRequestById_Should
	{
		[Test]
		public void BeInvoked_WhenBoardingRequestToDeleteIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserBoardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.AddBoardingRequest(validUserBoardingRequest.Object);
			boardingRequestService.DeleteBoardingRequestById(validUserBoardingRequest.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(validUserBoardingRequest.Object.Id));
		}

		[Test]
		public void BeInvokedOnceForTypeBoardingRequest_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserBoardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.AddBoardingRequest(validUserBoardingRequest.Object);
			boardingRequestService.DeleteBoardingRequestById(validUserBoardingRequest.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(validUserBoardingRequest.Object.Id), Times.Once);
		}

		[Test]
		public void CallSaveChangesTwice_WhenParamsAreValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserBoardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.AddBoardingRequest(validUserBoardingRequest.Object);
			boardingRequestService.DeleteBoardingRequestById(validUserBoardingRequest.Object.Id);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Exactly(2));
		}

		[Test]
		public void NotDeleteByIdBoardingRequest_WhichIsNotAdded()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			var validUserBoardingRequest = new Mock<UserBoardingRequest>();

			//Act, Assert
			mockedRepository.Verify(repository => repository.Delete(validUserBoardingRequest.Object.Id), Times.Never);
		}

		[Test]
		public void ThrowException_WhenBoardingRequestIsNull()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserBoardingRequest> validUserBoardingRequest = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => boardingRequestService.DeleteBoardingRequestById(validUserBoardingRequest.Object.Id));
		}
	}
}
