using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Args;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Requests.BoardingRequestTests.AddBoardingRequestTests
{
	[TestFixture]
	public class AddBoardingRequest_Should
	{
		[Test]
		public void AddRequest_WhenParamsAreValid()
		{
			var mockedBoardingRequestView = new Mock<IAddBoardingRequestView>();
			var mockedBoardingRequestService = new Mock<IBoardingRequestService>();

			mockedBoardingRequestView
				.SetupGet(x => x.Model)
				.Returns(new AddBoardingRequestModel());

			var addBoardingRequestPresenter = new AddBoardingRequestPresenter(mockedBoardingRequestView.Object, mockedBoardingRequestService.Object);

			var args = new AddBoardingRequestArgs()
			{
				PetName = It.IsAny<string>(),
				Age = It.IsAny<int>(),
				DateOfRequest = It.IsAny<DateTime>(),
				FromDate = It.IsAny<string>(),
				ToDate = It.IsAny<string>(),
				PetBreed = It.IsAny<string>(),
				ImageUrl = It.IsAny<string>(),
				UserId = It.IsAny<string>(),
				HotelManagerId = It.IsAny<string>()
			};
			
			mockedBoardingRequestView.Raise(x => x.AddBoardingRequest += null, args);

			mockedBoardingRequestService.Verify(x => x.AddBoardingRequest(args.PetName, args.Age,
					args.DateOfRequest, args.FromDate, args.ToDate, args.PetBreed, args.ImageUrl, args.UserId, args.HotelManagerId), Times.Once);
		}
	}
}
