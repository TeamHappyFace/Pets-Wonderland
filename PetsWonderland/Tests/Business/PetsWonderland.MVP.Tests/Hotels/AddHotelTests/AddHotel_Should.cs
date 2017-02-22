using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
				RequestId = It.IsAny<int>()
			};

			var hotel = new Hotel()
			{
				Name = args.HotelName,
				Location = new HotelLocation() { Address = args.Location },
				Description = args.HotelDescription,
				HotelManagerId = args.HotelManagerId,
				ImageUrl = args.ImageUrl
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
				Location = It.IsAny<string>(),
				HotelDescription = It.IsAny<string>(),
				HotelManagerId = It.IsAny<string>(),
				ImageUrl = It.IsAny<string>(),
				RequestId = It.IsAny<int>()
			};

			mockedHotelView.Raise(x => x.AddHotel += null, args);

			mockedHotelService.Verify(x => x.AddHotel(It.IsAny<Hotel>()), Times.Once);
		}
	}
}
