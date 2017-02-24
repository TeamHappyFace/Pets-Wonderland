using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Requests.HotelRegistrationRequestTests.AddHotelRequestTests
{
	[TestFixture]
	public class AddHotelRegistrationRequest_Should
	{
		[Test]
		public void AddRequest_WhenParamsAreValid()
		{
			var mockedHotelRequestView = new Mock<IAddHotelRequestView>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			mockedHotelRequestView
				.SetupGet(x => x.Model)
				.Returns(new AddHotelRequestModel());

			var addHotelRequestPresenter = new AddHotelRequestPresenter(mockedHotelRequestView.Object, mockedHotelRequestService.Object);

			var args = new AddHotelRequestArgs()
			{
				HotelName = It.IsAny<string>(),
				HotelLocation = It.IsAny<string>(),
				HotelDescription = It.IsAny<string>(),
				HotelManagerId = It.IsAny<string>(),
				DateOfRequest = It.IsAny<DateTime>(),
				ImageUrl = It.IsAny<string>(),
				IsAccepted = It.IsAny<bool>()
			};

			mockedHotelRequestView.Raise(x => x.AddHotelRegistrationRequest += null, args);

			mockedHotelRequestService.Verify(x => x.AddHotelRequest(args.HotelName, args.HotelLocation,
				args.HotelDescription, args.HotelManagerId, args.DateOfRequest, args.ImageUrl, args.IsAccepted), Times.Once);
		}
	}
}
