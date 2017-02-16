using System;
using Bytes2you.Validation;
using PetsWonderland.Business.MVP.Admin.CreateSlider.Args;
using PetsWonderland.Business.MVP.Content.Slider.Args;
using PetsWonderland.Business.MVP.Content.Slider.Contracts;
using PetsWonderland.Business.MVP.Content.Slider.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Content.Slider
{
    public class SliderPresenter : Presenter<ISliderView>, ISliderPresenter
    {
        private readonly ISliderService sliderService;
        
        public SliderPresenter(ISliderView view, ISliderService sliderService) 
            : base(view)
        {
            Guard.WhenArgument(view, "View cannot be null!").IsNull().Throw();
            Guard.WhenArgument(sliderService, "SliderService cannot be null!").IsNull().Throw();

            this.sliderService = sliderService;
        
            View.GetSliderData += GetSliderData;
        }

        public void GetSliderData(object sender, GetSliderDataArgs args)
        {
            var position = args.Position;

            Guard.WhenArgument(position, "Position is empty!").IsEmpty().Throw();

            this.View.Model.SliderData = this.sliderService.GetSliderByPosition(position);
        }
    }
}
