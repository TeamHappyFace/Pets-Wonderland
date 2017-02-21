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
		public void WorkProperly_WhenParamsAreValid()
		{
			var mockedHotelRequestView = new Mock<IAddHotelRequestView>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			mockedHotelRequestView
				.SetupGet(x => x.Model)
				.Returns(new AddHotelRequestModel());

			var addHotelRequestPresenter = new AddHotelRequestPresenter(mockedHotelRequestView.Object, mockedHotelRequestService.Object);

			var hotelRequest = new Mock<UserHotelRegistrationRequest>();

			mockedHotelRequestView.Raise(x => x.AddHotelRegistrationRequest += null,
				new AddHotelRequestArgs(hotelRequest.Object));

			Assert.AreEqual(1, mockedHotelRequestView.Object.Model.HotelRegistrationRequests.Count);
		}

		[Test]
		public void ThrowArgumentNullException_WhenNullRequest()
		{
			var mockedHotelRequestView = new Mock<IAddHotelRequestView>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			mockedHotelRequestView
				.SetupGet(x => x.Model)
				.Returns(new AddHotelRequestModel());

			var addHotelRequestPresenter = new AddHotelRequestPresenter(mockedHotelRequestView.Object, mockedHotelRequestService.Object);

			Assert.That(() =>
				mockedHotelRequestView.Raise(x => x.AddHotelRegistrationRequest += null,
				new AddHotelRequestArgs(null)),
				Throws.ArgumentNullException.With.Message.Contain("Hotel request to add is null!"));
		}
	}
}
