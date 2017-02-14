using System;
using PetsWonderland.Business.MVP.Content.Slider.Args;
using PetsWonderland.Business.MVP.Content.Slider.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Content.Slider.Views
{
    public interface ISliderView : IView<SliderViewModel>
    {
        event EventHandler<GetSliderDataArgs> GetSliderData;
    }
}