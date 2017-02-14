using System;
using PetsWonderland.Business.MVP.Content.Slider.Args;
using PetsWonderland.Business.MVP.Content.Slider.Contracts;
using PetsWonderland.Business.MVP.Content.Slider.Views;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Content.Slider
{
    public class SliderPresenter : Presenter<ISliderView>, ISliderPresenter
    {
        public void GetSliderData(object sender, GetSliderDataArgs e)
        {
            throw new NotImplementedException();
        }

        public SliderPresenter(ISliderView view) : base(view)
        {

        }
    }
}
