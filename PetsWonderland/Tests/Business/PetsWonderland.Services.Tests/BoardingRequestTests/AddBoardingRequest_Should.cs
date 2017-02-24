using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Args;
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
			
			var args = new Mock<AddBoardingRequestArgs>();
			boardingRequestService.AddBoardingRequest(args.Object.PetName, args.Object.Age, args.Object.DateOfRequest, args.Object.FromDate,
						args.Object.ToDate, args.Object.PetBreed, args.Object.ImageUrl, args.Object.UserId, args.Object.HotelManagerId);
			
			mockedRepository.Verify(repository => repository.Add(It.IsAny<UserBoardingRequest>()));
		}

		[Test]
		public void InvokeAddMethodOnceForBoardingRequest_WhenParamsAreCorrect()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var args = new Mock<AddBoardingRequestArgs>();
			boardingRequestService.AddBoardingRequest(args.Object.PetName, args.Object.Age, args.Object.DateOfRequest, args.Object.FromDate,
						args.Object.ToDate, args.Object.PetBreed, args.Object.ImageUrl, args.Object.UserId, args.Object.HotelManagerId);
			
			mockedRepository.Verify(repository => repository.Add(It.IsAny<UserBoardingRequest>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenBoardingRequestIsValid()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			var args = new Mock<AddBoardingRequestArgs>();
			boardingRequestService.AddBoardingRequest(args.Object.PetName, args.Object.Age, args.Object.DateOfRequest, args.Object.FromDate,
						args.Object.ToDate, args.Object.PetBreed, args.Object.ImageUrl, args.Object.UserId, args.Object.HotelManagerId);
			
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenBoardingRequestIsInvalid()
		{
			var mockedRepository = new Mock<IRepository<UserBoardingRequest>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var boardingRequestService = new BoardingRequestService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			Mock<AddBoardingRequestArgs> args = null;

			Assert.Throws<NullReferenceException>(() => boardingRequestService.AddBoardingRequest(args.Object.PetName, args.Object.Age, args.Object.DateOfRequest, args.Object.FromDate,
						args.Object.ToDate, args.Object.PetBreed, args.Object.ImageUrl, args.Object.UserId, args.Object.HotelManagerId));
		}
	}
}
