using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Requests.HotelRegistrationRequestTests.AddHotelRequestTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreatePresenter_WhenArgumentsAreValid()
		{
			var mockedHotelRequestView = new Mock<IAddHotelRequestView>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			var mockedHotelRequestModel = new AddHotelRequestModel();
			mockedHotelRequestView
				.SetupGet(x => x.Model)
				.Returns(mockedHotelRequestModel);

			Assert.DoesNotThrow(() =>
				new AddHotelRequestPresenter(mockedHotelRequestView.Object, mockedHotelRequestService.Object));
		}

		[Test]
		public void ThrowArgumentNullException_WhenHotelRequestServiceIsNull()
		{
			var mockedHotelRequestView = new Mock<IAddHotelRequestView>();

			Assert.That(() =>
				new AddHotelRequestPresenter(mockedHotelRequestView.Object, null),
				Throws.ArgumentNullException.With.Message.Contain("hotelRegistrationRequestService"));
		}
	}
}
