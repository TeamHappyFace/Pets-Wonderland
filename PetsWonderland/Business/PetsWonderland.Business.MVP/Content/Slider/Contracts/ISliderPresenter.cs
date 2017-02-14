using PetsWonderland.Business.MVP.Content.Slider.Args;

namespace PetsWonderland.Business.MVP.Content.Slider.Contracts
{
    public interface ISliderPresenter
    {
        void GetSliderData(object sender, GetSliderDataArgs e);
    }
}