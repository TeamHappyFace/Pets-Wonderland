using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.MVP.Hotels.AddHotel;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Args;
using PetsWonderland.Business.MVP.Hotels.AddHotel.ViewModels;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Hotels.AddHotelTests
{
	[TestFixture]
	public class AddHotel_Should
	{
		[Test]
		public void UpdateAccepted_WhenParamsAreValid()
		{
			var mockedHotelView = new Mock<IAddHotelView>();
			var mockedHotelService = new Mock<IHotelService>();
			var mockedHotelLocationService = new Mock<IHotelLocationService>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			mockedHotelView
				.SetupGet(x => x.Model)
				.Returns(new AddHotelModel());

			var addHotelPresenter = 
				new AddHotelPresenter(mockedHotelView.Object,
									mockedHotelService.Object,
									mockedHotelLocationService.Object,
									mockedHotelRequestService.Object);

			var args = new AddHotelArgs()
			{
				HotelName = It.IsAny<string>(),
				Location = It.IsAny<string>(),
				HotelDescription = It.IsAny<string>(),
				HotelManagerId = It.IsAny<string>(),
				ImageUrl = It.IsAny<string>(),
				RequestId = It.IsAny<int>(),
                IsDeleted = It.IsAny<bool>()
            };

			mockedHotelView.Raise(x => x.AddHotel += null, args);
			
			mockedHotelRequestService.Verify(x => x.UpdateAccepted(args.RequestId, true), Times.Once);		
		}

		[Test]
		public void AddHotel_WhenParamsAreValid()
		{
			var mockedHotelView = new Mock<IAddHotelView>();
			var mockedHotelService = new Mock<IHotelService>();
			var mockedHotelLocationService = new Mock<IHotelLocationService>();
			var mockedHotelRequestService = new Mock<IHotelRegistrationRequestService>();

			mockedHotelView
				.SetupGet(x => x.Model)
				.Returns(new AddHotelModel());

			var addHotelPresenter =
				new AddHotelPresenter(mockedHotelView.Object,
									mockedHotelService.Object,
									mockedHotelLocationService.Object,
									mockedHotelRequestService.Object);

			var args = new AddHotelArgs()
			{
				HotelName = It.IsAny<string>(),
				HotelDescription = It.IsAny<string>(),
				HotelManagerId = It.IsAny<string>(),
				ImageUrl = It.IsAny<string>(),
				RequestId = It.IsAny<int>(),
                IsDeleted = It.IsAny<bool>()
			};

			mockedHotelView.Raise(x => x.AddHotel += null, args);

			mockedHotelService.Verify(x => x.AddHotel(args.HotelName,
				args.HotelDescription, args.HotelManagerId, It.IsAny<HotelLocation>(), args.ImageUrl));
		}
	}
}
