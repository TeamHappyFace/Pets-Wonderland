using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Admin.ListSlider;
using PetsWonderland.Business.MVP.Admin.ListSlider.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Admin.ListSliderTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreatePresenter_WhenArgumentsAreValid()
		{
			var mockedListSlidersView = new Mock<IListSlidersView>();
			var mockedSliderService = new Mock<ISliderService>();

			Assert.DoesNotThrow(() =>
				new ListSlidersPresenter(mockedListSlidersView.Object, mockedSliderService.Object));
		}

		[Test]
		public void ThrowArgumentNullException_WhenHotelRequestServiceIsNull()
		{
			var mockedListSlidersView = new Mock<IListSlidersView>();

			Assert.That(() =>
				new ListSlidersPresenter(mockedListSlidersView.Object, null),
				Throws.ArgumentNullException.With.Message.Contain("ContentService cannot be null!"));
		}
	}
}
