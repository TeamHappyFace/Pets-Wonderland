using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.ViewModels;
using PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Requests.BoardingRequestTests.AddBoardingRequestTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreatePresenter_WhenArgumentsAreValid()
		{
			var mockedBoardingRequestView= new Mock<IAddBoardingRequestView>();
			var mockedBoardingRequestService = new Mock<IBoardingRequestService>();

			var mockedBoardingRequestModel = new AddBoardingRequestModel();
			mockedBoardingRequestView
				.SetupGet(x => x.Model)
				.Returns(mockedBoardingRequestModel);

			Assert.DoesNotThrow(() =>
				new AddBoardingRequestPresenter(mockedBoardingRequestView.Object, mockedBoardingRequestService.Object));
		}

		[Test]
		public void ThrowArgumentNullException_WhenBoardingRequestServiceIsNull()
		{
			var mockedBoardingRequestView = new Mock<IAddBoardingRequestView>();

			Assert.That(() =>
				new AddBoardingRequestPresenter(mockedBoardingRequestView.Object, null),
				Throws.ArgumentNullException.With.Message.Contain("boardingRequestService"));
		}
	}
}
