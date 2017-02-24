using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Args;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Requests.HotelRegistrationRequestTests.DeleteHotelRequestTests
{
	[TestFixture]
	public class DeleteHotelRegistrationRequest_Should
	{
		[Test]
		public void UpdateDeletedOnce_WhenParamsAreValid()
		{
			var mockedHotelRequestView = new Mock<IDeleteHotelRequestView>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			mockedHotelRequestView
				.SetupGet(x => x.Model)
				.Returns(new DeleteHotelRequestModel());

			var deleteHotelRequestPresenter = 
				new DeleteHotelRequestPresenter(mockedHotelRequestView.Object, mockedHotelRequestService.Object);

			var hotelRequest = new Mock<UserHotelRegistrationRequest>();

			mockedHotelRequestView.Raise(x => x.DeleteHotelRegistrationRequest += null,
				new DeleteHotelRequestArgs(hotelRequest.Object.Id));

			mockedHotelRequestService
				.Verify(x => x.UpdateDeleted(hotelRequest.Object.Id, true), Times.Once());
		}
	}
}
