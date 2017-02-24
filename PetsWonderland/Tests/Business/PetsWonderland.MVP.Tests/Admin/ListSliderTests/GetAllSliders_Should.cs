using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetsWonderland.Business.Models.Pages;
using PetsWonderland.Business.MVP.Admin.ListSlider;
using PetsWonderland.Business.MVP.Admin.ListSlider.Args;
using PetsWonderland.Business.MVP.Admin.ListSlider.ViewModels;
using PetsWonderland.Business.MVP.Admin.ListSlider.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Admin.ListSliderTests
{
	[TestClass]
	public class GetAllSliders_Should
	{
		[TestMethod]
		public void CallGetAllOnce_WhenParamsAreValid()
		{
			var mockedListSlidersView = new Mock<IListSlidersView>();
			var mockedSliderService = new Mock<ISliderService>();

			var expectedResult = new List<Slider>()
			{
				new Slider(),
				new Slider(),
				new Slider()
			};

			var mockedModel = new ListSlidersViewModel();

			mockedListSlidersView
				.SetupGet(x => x.Model)
				.Returns(mockedModel);

			mockedSliderService
				.Setup(x => x.GetAllSliders())
				.Returns(expectedResult.AsQueryable());

			var listSlidersPresenter = new ListSlidersPresenter(mockedListSlidersView.Object, mockedSliderService.Object);

			var args = new GetAllSlidersArgs();

			mockedListSlidersView.Raise(x => x.GetSlidersList += null, args);

			mockedSliderService.Verify(x => x.GetAllSliders(), Times.Once);
		}
	}
}
