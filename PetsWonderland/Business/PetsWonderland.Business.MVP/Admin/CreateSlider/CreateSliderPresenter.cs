using Bytes2you.Validation;
using PetsWonderland.Business.MVP.Admin.CreateSlider.Args;
using PetsWonderland.Business.MVP.Admin.CreateSlider.Contracts;
using PetsWonderland.Business.MVP.Admin.CreateSlider.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Admin.CreateSlider
{
    public class CreateSliderPresenter : Presenter<ICreateSliderView>, ICreateSliderPresenter
    {
        private readonly ISliderService sliderService;

        public CreateSliderPresenter(ICreateSliderView view, ISliderService sliderService) : base(view)
        {
            Guard.WhenArgument(view, "View cannot be null!").IsNull().Throw();
            Guard.WhenArgument(sliderService, "ContentService cannot be null!").IsNull().Throw();

            this.sliderService = sliderService;

            View.CreateSlider += CreateSlider;
        }

        public void CreateSlider(object sender, CreateSliderArgs e)
        {
            var result = this.sliderService.CreateSlider(e.Name, e.Postition);

            this.View.Model.SliderCreatedSuccessfully = result;
        }
    }
}
