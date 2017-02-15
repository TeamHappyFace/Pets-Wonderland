using System;
using Bytes2you.Validation;
using PetsWonderland.Business.MVP.Content.Slider.Args;
using PetsWonderland.Business.MVP.Content.Slider.Contracts;
using PetsWonderland.Business.MVP.Content.Slider.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Content.Slider
{
    public class SliderPresenter : Presenter<ISliderView>, ISliderPresenter
    {
        private readonly IPageContentService contentService;
        
        public SliderPresenter(ISliderView view, IPageContentService contentService) 
            : base(view)
        {
            Guard.WhenArgument(view, "View cannot be null!").IsNull().Throw();
            Guard.WhenArgument(contentService, "ContentService cannot be null!").IsNull().Throw();

            this.contentService = contentService;
        
            View.GetSliderData += GetSliderData;
        }

        public void GetSliderData(object sender, GetSliderDataArgs args)
        {
            var position = args.Position;

            Guard.WhenArgument(position, "Position is empty!").IsEmpty().Throw();

            this.View.Model.SliderData = this.contentService.GetSliderByPosition(position);
        }
    }
}
