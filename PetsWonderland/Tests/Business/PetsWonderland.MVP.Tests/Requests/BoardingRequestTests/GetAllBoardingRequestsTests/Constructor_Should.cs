using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.ViewModels;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.GetAllBoardingRequests.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Requests.BoardingRequestTests.GetAllBoardingRequestsTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreatePresenter_WhenArgumentsAreValid()
		{
			var mockedBoardingRequestView = new Mock<IGetAllBoardingRequestsView>();
			var mockedBoardingRequestService = new Mock<IBoardingRequestService>();

			var mockedBoardingRequestModel = new GetAllBoardingRequestsModel();
			mockedBoardingRequestView
				.SetupGet(x => x.Model)
				.Returns(mockedBoardingRequestModel);

			Assert.DoesNotThrow(() =>
				new GetAllBoardingRequestsPresenter(mockedBoardingRequestView.Object, mockedBoardingRequestService.Object));
		}

		[Test]
		public void ThrowArgumentNullException_WhenBoardingRequestServiceIsNull()
		{
			var mockedBoardingRequestView = new Mock<IGetAllBoardingRequestsView>();

			Assert.That(() =>
				new GetAllBoardingRequestsPresenter(mockedBoardingRequestView.Object, null),
				Throws.ArgumentNullException.With.Message.Contain("boardingRequestService"));
		}
	}
}
