using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Args;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.ViewModels;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Requests.BoardingRequestTests.GetAllBoardingRequestsTests
{
	[TestClass]
	public class GetAllBoardingRequests_Should
	{
		[TestMethod]
		public void SetModelRequests_WhenParamsAreValid()
		{
			var mockedBoardingRequestView = new Mock<IGetAllBoardingRequestsView>();
			var mockedBoardingRequestService = new Mock<IBoardingRequestService>();

			var expectedResult = new List<UserBoardingRequest>()
			{
				new UserBoardingRequest(),
				new UserBoardingRequest(),
				new UserBoardingRequest()
			};

			var mockedModel = new GetAllBoardingRequestsModel();

			mockedBoardingRequestView
				.SetupGet(x => x.Model)
				.Returns(mockedModel);

			mockedBoardingRequestService
				.Setup(x => x.GetAllBoardingRequests())
				.Returns(expectedResult.AsQueryable());

			var getAllBoardingRequestsPresenter = new GetAllBoardingRequestsPresenter(mockedBoardingRequestView.Object, mockedBoardingRequestService.Object);

			var args = new GetAllBoardingRequestsArgs()
			{
				BoardingRequests = new List<UserBoardingRequest>().AsQueryable()
			};

			mockedBoardingRequestView.Raise(x => x.GetAllBoardingRequests += null, args);

			Assert.IsNotNull(mockedBoardingRequestView.Object.Model.BoardingRequests);
		}
	}
}
