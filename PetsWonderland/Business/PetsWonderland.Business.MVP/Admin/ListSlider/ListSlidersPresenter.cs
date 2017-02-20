using Bytes2you.Validation;
using PetsWonderland.Business.MVP.Admin.ListSlider.Args;
using PetsWonderland.Business.MVP.Admin.ListSlider.Contracts;
using PetsWonderland.Business.MVP.Admin.ListSlider.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Admin.ListSlider
{
    public class ListSlidersPresenter: Presenter<IListSlidersView>, IListSlidersPresenter
    {
        private readonly ISliderService sliderService;

        public ListSlidersPresenter(IListSlidersView view, ISliderService sliderService) : base(view)
        {
            Guard.WhenArgument(view, "View cannot be null!").IsNull().Throw();
            Guard.WhenArgument(sliderService, "ContentService cannot be null!").IsNull().Throw();

            this.sliderService = sliderService;

            View.GetSlidersList += GetAllSliders;
            View.DeleteSlider += DeleteSlider;
        }     

        public void GetAllSliders(object sender, GetAllSlidersArgs e)
        {
            this.View.Model.AllSliders = this.sliderService.GetAllSliders();
        }

        public void DeleteSlider(object sender, DeleteSliderArgs e)
        {
            this.sliderService.DeleteSlider(e.SliderId);
        }
    }
}
