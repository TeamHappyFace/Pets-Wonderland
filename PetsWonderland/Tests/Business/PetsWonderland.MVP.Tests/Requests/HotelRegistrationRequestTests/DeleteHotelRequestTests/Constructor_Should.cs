using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Requests.HotelRegistrationRequestTests.DeleteHotelRequestTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreatePresenter_WhenArgumentsAreValid()
		{
			var mockedHotelRequestView = new Mock<IDeleteHotelRequestView>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			var mockedHotelRequestModel = new DeleteHotelRequestModel();
			mockedHotelRequestView
				.SetupGet(x => x.Model)
				.Returns(mockedHotelRequestModel);

			Assert.DoesNotThrow(() =>
				new DeleteHotelRequestPresenter(mockedHotelRequestView.Object, mockedHotelRequestService.Object));
		}

		[Test]
		public void ThrowArgumentNullException_WhenHotelRequestServiceIsNull()
		{
			var mockedHotelRequestView = new Mock<IDeleteHotelRequestView>();

			Assert.That(() =>
				new DeleteHotelRequestPresenter(mockedHotelRequestView.Object, null),
				Throws.ArgumentNullException.With.Message.Contain("hotelRegistrationRequestService"));
		}
	}
}
