using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Requests.HotelRegistrationRequestTests.GetAllHotelRequestTests
{
	[TestClass]
	public class GetAllHotelRegistrationRequests_Should
	{
		[TestMethod]
		public void WorkProperly_WhenParamsAreValid()
		{
			var mockedHotelRequestView = new Mock<IGetAllHotelRequestView>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			var expectedResult = new List<UserHotelRegistrationRequest>()
			{
				new UserHotelRegistrationRequest(),
				new UserHotelRegistrationRequest(),
				new UserHotelRegistrationRequest()
			};

			var mockedModel = new GetAllHotelRequestModel();

			mockedHotelRequestView
				.SetupGet(x => x.Model)
				.Returns(mockedModel);

			mockedHotelRequestService
				.Setup(x => x.GetAllHotelRequests())
				.Returns(expectedResult.AsQueryable());

			var getAllBoardingRequestsPresenter = 
				new GetAllHotelRequestPresenter(mockedHotelRequestView.Object, mockedHotelRequestService.Object);

			var args = new GetAllHotelRequestsArgs()
			{
				HotelRequests = new List<UserHotelRegistrationRequest>().AsQueryable()
			};

			mockedHotelRequestView.Raise(x => x.GetAllHotelRequests += null, args);

			Assert.IsNotNull(mockedHotelRequestView.Object.Model.HotelRegistrationRequests);
		}
	}
}
