using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Hotels.AddHotel;
using PetsWonderland.Business.MVP.Hotels.AddHotel.ViewModels;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Hotels.AddHotelTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreatePresenter_WhenArgumentsAreValid()
		{
			var mockedHotelView = new Mock<IAddHotelView>();
			var mockedHotelService = new Mock<IHotelService>();
			var mockedHotelLocationService = new Mock<IHotelLocationService>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			var mockedHotetModel = new AddHotelModel();
			mockedHotelView
				.SetupGet(x => x.Model)
				.Returns(mockedHotetModel);

			Assert.DoesNotThrow(() =>
				new AddHotelPresenter(mockedHotelView.Object,
									mockedHotelService.Object,
									mockedHotelLocationService.Object,
									mockedHotelRequestService.Object));
		}

		[Test]
		public void ThrowArgumentNullException_WhenHotelServiceIsNull()
		{
			var mockedHotelView = new Mock<IAddHotelView>();
			var mockedHotelLocationService = new Mock<IHotelLocationService>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			Assert.That(() =>
				new AddHotelPresenter(mockedHotelView.Object, 
										null,
										mockedHotelLocationService.Object,
										mockedHotelRequestService.Object),
				Throws.ArgumentNullException.With.Message.Contain("hotelService"));
		}

		[Test]
		public void ThrowArgumentNullException_WhenHotelLocationServiceIsNull()
		{
			var mockedHotelView = new Mock<IAddHotelView>();
			var mockedHotelService = new Mock<IHotelService>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			Assert.That(() =>
				new AddHotelPresenter(mockedHotelView.Object,
										mockedHotelService.Object,
										null,
										mockedHotelRequestService.Object),
				Throws.ArgumentNullException.With.Message.Contain("hotelLocationService"));
		}

		[Test]
		public void ThrowArgumentNullException_WhenHotelRequestServiceIsNull()
		{
			var mockedHotelView = new Mock<IAddHotelView>();
			var mockedHotelService = new Mock<IHotelService>();
			var mockedHotelLocationService = new Mock<IHotelLocationService>();

			Assert.That(() =>
				new AddHotelPresenter(mockedHotelView.Object,
										mockedHotelService.Object,
										mockedHotelLocationService.Object,
										null),
				Throws.ArgumentNullException.With.Message.Contain("hotelRegistrationRequestService"));
		}
	}
}
