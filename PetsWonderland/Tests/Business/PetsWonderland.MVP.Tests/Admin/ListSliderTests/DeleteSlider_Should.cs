using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Models.Pages;
using PetsWonderland.Business.MVP.Admin.ListSlider;
using PetsWonderland.Business.MVP.Admin.ListSlider.Args;
using PetsWonderland.Business.MVP.Admin.ListSlider.ViewModels;
using PetsWonderland.Business.MVP.Admin.ListSlider.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Admin.ListSliderTests
{
	[TestFixture]
	public class DeleteSlider_Should
	{
		[Test]
		public void UpdateDeletedOnce_WhenParamsAreValid()
		{
			var mockedListSlidersView = new Mock<IListSlidersView>();
			var mockedSliderService = new Mock<ISliderService>();

			mockedListSlidersView
				.SetupGet(x => x.Model)
				.Returns(new ListSlidersViewModel());

			var listSlidersPresenter =
				new ListSlidersPresenter(mockedListSlidersView.Object, mockedSliderService.Object);

			var slider = new Mock<Slider>();

			mockedListSlidersView.Raise(x => x.DeleteSlider += null,
				new DeleteSliderArgs());

			mockedSliderService
				.Verify(x => x.DeleteSlider(slider.Object.Id), Times.Once());
		}
	}
}
