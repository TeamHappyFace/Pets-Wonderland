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
			//Arrange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var boardingRequest = new Mock<UserBoardingRequest>();
			boardingRequestService.GetById(boardingRequest.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.GetById(boardingRequest.Object.Id), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotUsed()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedRepository.Verify(repository => repository.GetById(1), Times.Never);
		}

		[Test]
		public void ReturnBoardingRequest_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			var boardingRequest = new Mock<UserBoardingRequest>();
			mockedRepository.Setup(repository => repository.GetById(boardingRequest.Object.Id))
				.Returns(() => boardingRequest.Object);

			//Act, Assert
			Assert.IsInstanceOf<UserBoardingRequest>(boardingRequestService.GetById(boardingRequest.Object.Id));
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var boardingRequest = new Mock<UserBoardingRequest>();
			mockedRepository.Setup(repository => repository.GetById(boardingRequest.Object.Id))
				.Returns(() => boardingRequest.Object);

			//Assert
			Assert.AreEqual(boardingRequestService.GetById(boardingRequest.Object.Id), boardingRequest.Object);
		}

		[Test]
		public void ReturnCorrectBoardingRequest_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var boardingRequest = new Mock<UserBoardingRequest>();
			var boardingRequestToCompare = new Mock<UserBoardingRequest>();
			mockedRepository.Setup(repository => repository.GetById(boardingRequest.Object.Id))
				.Returns(() => boardingRequest.Object);

			//Assert
			Assert.AreNotEqual(boardingRequestService.GetById(boardingRequest.Object.Id), boardingRequestToCompare.Object);
		}

		[Test]
		public void NotReturnBoardingRequest_WhenNoSuchBoardingRequest()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			mockedRepository.Setup(repository => repository.GetById(0)).Returns(() => null);

			//Assert
			Assert.IsNull(boardingRequestService.GetById(0));
		}

		[Test]
		public void ThrowException_WhenNullBoardingRequest()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			Mock<UserBoardingRequest> boardingRequest = null;

			//Assert
			Assert.Throws<NullReferenceException>(() => boardingRequestService.GetById(boardingRequest.Object.Id));
		}
	}
}
