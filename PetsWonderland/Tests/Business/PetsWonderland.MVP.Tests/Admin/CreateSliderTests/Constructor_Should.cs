using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Admin.CreateSlider;
using PetsWonderland.Business.MVP.Admin.CreateSlider.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Admin.CreateSliderTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreatePresenter_WhenArgumentsAreValid()
		{
			var mockedCreateSliderView = new Mock<ICreateSliderView>();
			var mockedSliderService = new Mock<ISliderService>();

			Assert.DoesNotThrow(() =>
				new CreateSliderPresenter(mockedCreateSliderView.Object, mockedSliderService.Object));
		}

		[Test]
		public void ThrowArgumentNullException_WhenHotelRequestServiceIsNull()
		{
			var mockedListSlidersView = new Mock<ICreateSliderView>();

			Assert.That(() =>
				new CreateSliderPresenter(mockedListSlidersView.Object, null),
				Throws.ArgumentNullException.With.Message.Contain("SliderService cannot be null!"));
		}
	}
}
