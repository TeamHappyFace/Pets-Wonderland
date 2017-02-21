using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.GetAllHotelRequest.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Requests.HotelRegistrationRequestTests.GetAllHotelRequestTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreatePresenter_WhenArgumentsAreValid()
		{
			var mockedHotelRequestView = new Mock<IGetAllHotelRequestView>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			var mockedHotelRequestModel = new GetAllHotelRequestModel();
			mockedHotelRequestView
				.SetupGet(x => x.Model)
				.Returns(mockedHotelRequestModel);

			Assert.DoesNotThrow(() =>
				new GetAllHotelRequestPresenter(mockedHotelRequestView.Object, mockedHotelRequestService.Object));
		}

		[Test]
		public void ThrowArgumentNullException_WhenHotelRequestServiceIsNull()
		{
			var mockedHotelRequestView = new Mock<IGetAllHotelRequestView>();

			Assert.That(() =>
				new GetAllHotelRequestPresenter(mockedHotelRequestView.Object, null),
				Throws.ArgumentNullException.With.Message.Contain("hotelRegistrationRequestService"));
		}
	}
}
