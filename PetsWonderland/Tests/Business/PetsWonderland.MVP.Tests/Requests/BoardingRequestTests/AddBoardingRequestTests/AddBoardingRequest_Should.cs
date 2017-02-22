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

			var boardingRequest = new Mock<UserBoardingRequest>();

			mockedBoardingRequestView.Raise(x => x.AddBoardingRequest += null, 
				new AddBoardingRequestArgs(boardingRequest.Object));

			Assert.AreEqual(1, mockedBoardingRequestView.Object.Model.BoardingRequests.Count);
		}

		[Test]
		public void ThrowArgumentNullException_WhenNullRequest()
		{
			var mockedBoardingRequestView = new Mock<IAddBoardingRequestView>();
			var mockedBoardingRequestService = new Mock<IBoardingRequestService>();

			mockedBoardingRequestView
				.SetupGet(x => x.Model)
				.Returns(new AddBoardingRequestModel());

			var addBoardingRequestPresenter = new AddBoardingRequestPresenter(mockedBoardingRequestView.Object, mockedBoardingRequestService.Object);
			
			Assert.That(() =>
				mockedBoardingRequestView.Raise(x => x.AddBoardingRequest += null,
				new AddBoardingRequestArgs(null)),
				Throws.ArgumentNullException.With.Message.Contain("Boarding request to add is null!"));
		}
	}
}
