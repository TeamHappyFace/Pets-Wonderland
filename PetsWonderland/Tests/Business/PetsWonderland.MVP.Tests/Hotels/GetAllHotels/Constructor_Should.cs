using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.ViewModels;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Hotels.GetAllHotels
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreatePresenter_WhenArgumentsAreValid()
		{
			var mockedHotelView = new Mock<IGetAllHotelsView>();
			var mockedHotelService = new Mock<IHotelService>();

			var mockedHotetModel = new GetAllHotelsModel();
			mockedHotelView
				.SetupGet(x => x.Model)
				.Returns(mockedHotetModel);

			Assert.DoesNotThrow(() =>
				new GetAllHotelsPresenter(mockedHotelView.Object, mockedHotelService.Object));
		}

		[Test]
		public void ThrowArgumentNullException_WhenHotelServiceIsNull()
		{
			var mockedHotelView = new Mock<IGetAllHotelsView>();

			Assert.That(() =>
				new GetAllHotelsPresenter(mockedHotelView.Object, null),
				Throws.ArgumentNullException.With.Message.Contain("hotelService"));
		}
	}
}
