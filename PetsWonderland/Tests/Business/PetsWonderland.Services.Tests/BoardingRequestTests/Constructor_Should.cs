using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.BoardingRequestTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateBoardingRequestService_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			Assert.That(boardingRequestService, Is.InstanceOf<BoardingRequestService>());
		}

		[Test]
		public void ThrowNullException_WhenRepositoryIsNull()
		{
			//Arrange
			Mock<IRepository<UserBoardingRequest>> mockedRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object));
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object));
		}
	}
}
